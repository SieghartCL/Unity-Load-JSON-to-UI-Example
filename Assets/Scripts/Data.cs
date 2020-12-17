using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    //Aquí se añadirían los campos del JSON. Finalmente no se utilizará debido a que preferí trabajar
    //directamente con los datos del JSON como Texto, y al no haber podido implementar un manejo eficiente
    //de los datos del JSON como array de objetos
    public string ID = "";
    public string Name = "";
    public string Role = "";
    public string Nickname = "";
}