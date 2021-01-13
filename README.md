# Unity Load JSON to UI Example

## Español/Spanish:
### Versión de App: 1.0 dev
### Versión de Unity: 2019.4.17f1 (LTS)
### Descripción:

- Esta pequeña aplicación es un ejemplo funcional de cómo cargar y mostrar datos de un archivo JSON al UI de Unity. Se comienza con la *deserialización del archivo JSON* **JsonChallenge.json** en clases en lo que al título y los nombres de las columnas respecta, mientras que los datos de las filas son tratados como un **string** y posterior al reemplazo de carácteres que se le aplica, un **array de strings**.

- La misma **es capaz de listar** (en teoría) *cualquier número de columnas y filas*, acomodando cada registro uno al lado (o debajo) del otro (aunque sin scrolling vertical/horizontal) según la referencia que se le da con la primera plantilla de columna y fila (registro), visible al situarse en la escena y antes de hacer andar el proyecto.

- Una vez andando, se pueden **recargar los datos cargados en cualquier momento** haciendo click en el botón *Reload Data*. Si se añaden o remueven columnas y filas al editar el archivo JSON (dado que **debe existir la relación del nombre de la columna** y del **nombre en el par clave-valor de los datos**) y se realiza este procedimiento, se *añadirán o removerán* los registros respectivos.

- Cuenta con 2 comprobaciones fundamentales: la *existencia del archivo JSON* en el directorio **Assets/StreamingAssets/JsonChallenge.json**, y un *pequeño manejo de errores* al momento de comprobar campos no existentes respecto a la comprobación de su título. En la primera, *si no existe el archivo*, **mostrará en el placeholder del título de la tabla que no se encontró el archivo**, mientras que en la segunda, **evitará que se caiga la aplicación al no encontrar la relación del nombre de la columna con el nombre en el par clave-valor de los datos** mientras *intenta continuar* la carga de los datos.

- Cualquier ayuda o sugerencia en cómo poder mejorar este ejemplo, será bienvenida! Espero que les sea útil a las personas que no tengan muchas nociones como yo en lo que es UI y carga de datos usando JSON con C# en Unity 😁


## Inglés/English:
### App Version: 1.0 dev
### Unity Version: 2019.4.17f1 (LTS)
### Description:

- This little app is a working example of how to load and display data from a JSON file to the Unity UI. It begins with the *deserialization of the JSON file* **JsonChallenge.json** in classes as far as the title and column names are concerned, while the data in the rows is treated as a **string** and later to the replacement of characters that is applied, an **array of strings**.

- It **is capable of listing** (in theory) *any number of columns and rows*, arranging each record next to (or below) the other (although without vertical/horizontal scrolling) according to the reference that is given to it with the first column and row template (record), visible when standing on the scene and before starting the project.

- Once running, you can **reload the loaded data at any time** by clicking on the *Reload Data* button. If columns and rows are added or removed when editing the JSON file (since **the relationship of the column name** and the **name must exist in the key-value pair of the data**) and this is done procedure, *the respective records will be* added or removed.

- It has 2 fundamental checks: the *existence of the JSON file* in the **Assets/StreamingAssets/JsonChallenge.json** directory, and a *small error handling* when checking non-existent fields regarding the verification of their title. In the first one, *if the file does not exist*, **it will show in the table title placeholder that the file was not found**, while in the second, **it will prevent the application from crashing by not finding the file relationship of the column name to the name in the data key-value pair** while *trying to continue* loading the data.

- Any help or suggestion on how to improve this example will be welcome! I hope it is useful to people who do not have many notions like me in what is UI and data loading using JSON with C# in Unity 😁
