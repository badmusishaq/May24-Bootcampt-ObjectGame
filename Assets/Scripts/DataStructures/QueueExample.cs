using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueExample : MonoBehaviour
{
    public GameObject objPrefab;
    public Queue<GameObject> objQueue = new Queue<GameObject>();

    GameObject tempObj;
    Vector2 lastEnqueuePosition = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Push object to the stack
        if (Input.GetKeyDown(KeyCode.A))
        {
            tempObj = Instantiate(objPrefab, transform);
            tempObj.transform.position = new Vector2(lastEnqueuePosition.x +1, 0);

            tempObj.name = "QUEUED-" + objQueue.Count;
            tempObj.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

            objQueue.Enqueue(tempObj);
            lastEnqueuePosition = tempObj.transform.position;

            Debug.Log("Enqueued " + tempObj.name);
        }


        if (Input.GetKeyDown(KeyCode.X))
        {
            var removedObj = objQueue.Dequeue();
            Destroy(removedObj);
            Debug.Log("Popped from the stack: " + removedObj);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log($"Object at the top is : {objQueue.Peek().name}");
        }
    }
}
