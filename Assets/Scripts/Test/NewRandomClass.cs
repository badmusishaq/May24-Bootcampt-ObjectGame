using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRandomClass : MonoBehaviour
{
    static int myNumber = 5;

    // Start is called before the first frame update
    void Start()
    {
        myNumber++;
        RandomClass.NumberMethod();
        Debug.Log($"My number = {myNumber}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void AddNumber()
    {
        myNumber++;
    }
}
