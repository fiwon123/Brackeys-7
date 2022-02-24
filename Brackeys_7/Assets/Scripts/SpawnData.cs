using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnData", order = 1)]
public class SpawnData : ScriptableObject
{
    public enum shapes { SQUARE, RECTANGLE };
    public enum sizes { SMALL, MEDIUM, LARGE };

    public shapes currentShape;
    public sizes currentSize;
    public Vector2 size;
    public Sprite[] backgroundGenerator;

}
