using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CustomDataExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*CustomData customData = new CustomData();

        customData.name = "Lizzy";

        customData.address = new Address();
        customData.address.unit = 5;
        customData.address.road = "McDonald road";
        customData.address.city = "New York";

        customData.books = new Book[2];

        customData.books[0] = new Book();
        customData.books[0].bookName = "Intro to Game Dev";
        customData.books[0].bookAuthor = "James Shark";
        customData.books[0].isDigital = false;
        customData.books[0].yearofPublication = 2005;

        customData.books[1] = new Book();
        customData.books[1].bookName = "Intro to Software Engineering";
        customData.books[1].bookAuthor = "Wale Johnson";
        customData.books[1].isDigital = true;
        customData.books[1].yearofPublication = 2020;*/

        //Data serialization
        //string data = JsonUtility.ToJson(customData);

        //Debug.Log($"Json data = {data}");

        string filePath = Path.Combine(Application.dataPath, "JSONFolder/customJSONFile.json");
        //File.WriteAllText(filePath, data);

        string json = File.ReadAllText(filePath);

        //Data Deserialization
        CustomData deserializedCustomData = JsonUtility.FromJson<CustomData>(json);

        string name = deserializedCustomData.name;
        string firstBookName = deserializedCustomData.books[0].bookName;
        Debug.Log($"The user name is {name}, the first book they are rading is {firstBookName}");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
