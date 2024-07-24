using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackExample : MonoBehaviour
{
    public GameObject objectPrefab;
    public Stack<GameObject> objStack = new Stack<GameObject>();

    GameObject tempObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Push object to the stack
        if(Input.GetKeyDown(KeyCode.A))
        {
            tempObj = Instantiate(objectPrefab, transform);
            tempObj.transform.position = new Vector2(0, objStack.Count);

            tempObj.name = "STACKED-" + objStack.Count;
            tempObj.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

            objStack.Push(tempObj);

            Debug.Log("Pushed " + tempObj.name);
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            var removedObj = objStack.Pop();
            Destroy(removedObj);
            Debug.Log("Popped from the stack: " + removedObj);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log($"Object at the top is : {objStack.Peek().name}");
        }
    }
}
