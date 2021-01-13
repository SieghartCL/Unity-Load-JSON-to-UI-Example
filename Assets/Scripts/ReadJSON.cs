using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadJSON : MonoBehaviour
{
    TableData tableData = new TableData();
    Transform dataContainer;
    Transform columnTemplate;
    Transform rowTemplate;

    // Start is called before the first frame update
    void Start()
    {
        //Al Inicio, se le añade un evento al botón en pantalla para que recargue el nivel
        var button = GameObject.Find("ReloadButton").GetComponent<Button>();
        button.onClick.AddListener(() =>
            {
                Application.LoadLevel(0);
            });
        //Y luego, se cargan los datos
        LoadData();
    }

    public void LoadData()
    {
        //Se construye la ruta del archivo JSON con el que se trabajará
        string jsonPath = Application.dataPath + "/StreamingAssets/JsonChallenge.json";
        //Se obtiene información sobre los GameObjects con los que se trabajarán
        Text dataTitle = GameObject.Find("TitleTemplate").GetComponent<Text>();
        dataContainer = GameObject.Find("DataContainer").transform;
        columnTemplate = dataContainer.Find("ColumnTemplate");
        rowTemplate = dataContainer.Find("RowTemplate");
        //Se ocultan las plantillas
        columnTemplate.gameObject.SetActive(false);
        rowTemplate.gameObject.SetActive(false);
        //Se definen ciertos parámetros que se usarán a lo largo de la función
        float spaceBetween = 100;
        float height = 25f, accHeight = 0;

        //Obtener los datos desde el archivo JSON como string y parsearlo a JSON
        //en base a la plantilla de datos (TableData)
        if (File.Exists(jsonPath))
        {
            string json = File.ReadAllText(jsonPath);
            string data = json.Split(new string[] { "Data" }, StringSplitOptions.None)[1].Remove(0, 3);
            string[] dataArray = data.Replace("{", string.Empty).Replace("}", string.Empty).Replace("\"", string.Empty)
                                 .Replace("[", string.Empty).Replace("]", string.Empty).Trim().Split(',');
            tableData = JsonUtility.FromJson<TableData>(json);

            //EL título en la propiedad Title
            dataTitle.text = tableData.Title;

            //Las columnas en la propiedad ColumnHeaders
            var i = 0;
            foreach (var header in tableData.ColumnHeaders)
            {
                //Debug.Log("Column Headers(" + i + "): " + header);
                Transform columnTransform = Instantiate(columnTemplate, dataContainer);
                columnTransform.GetComponent<Text>().text = header;
                RectTransform columnRectTransform = columnTransform.GetComponent<RectTransform>();
                columnRectTransform.anchoredPosition = new Vector2(spaceBetween * i, 0);
                columnTransform.gameObject.SetActive(true);
                i++;
            }

            //Los datos de cada celda en la fila en la propiedad Data
            int internalIndex = 0;
            for (int k = 0; k < tableData.ColumnHeaders.Length; k++)
            {
                i = 0;
                Transform rowTransform;
                RectTransform rowRectTransform;
                do
                {
                    rowTransform = Instantiate(rowTemplate, dataContainer);

                    //Manejo de errores para los casos en los que hayan datos no existentes según la posición de la columna
                    //No funciona perfecto, pero al menos evitará que se caiga la aplicación
                    try
                    {
                        if (dataArray[internalIndex].Split(':')[0].Trim() == tableData.ColumnHeaders[i])
                        {
                            rowTransform.GetComponent<Text>().text = dataArray[internalIndex].Split(':')[1];
                            rowRectTransform = rowTransform.GetComponent<RectTransform>();
                            //Una vez que se cumpla una iteración del Do While, aquí se irá añadiendo el espacio vertical
                            //necesario para acomodar en formato de tabla los datos del JSON
                            rowRectTransform.anchoredPosition = new Vector2(spaceBetween * i, -height * accHeight);
                            rowTransform.gameObject.SetActive(true);
                        }
                    }
                    catch (System.IndexOutOfRangeException)
                    {
                        Debug.Log("El valor de " + tableData.ColumnHeaders[i] + " no existe en el Array de Datos");
                    }
                    i++;
                    internalIndex++;
                }
                while (i < tableData.ColumnHeaders.Length);

                accHeight++;
            }
        }
        else
        {
            dataTitle.text = "No se encontró el archivo JSON. Intente nuevamente";
        }
    }
}