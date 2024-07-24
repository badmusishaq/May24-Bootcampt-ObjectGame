using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MyScriptableData", menuName = "CircuitStream/May24 Bootcamp/Create New Object", order = 1)]
public class ScriptableObjectExample : ScriptableObject
{
    public string objectName;
    public int score;
    public Vector2 startPos;
}
