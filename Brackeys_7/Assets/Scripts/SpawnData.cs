using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnData")]
public class SpawnData : ScriptableObject
{
    public enum shapes { SQUARE, HORIZONTAL, VERTICAL, FLAT };
    public enum sizes { SMALL, MEDIUM, LARGE, UNIQUE_SIZE };

    public shapes currentShape;
    public sizes currentSize;
    public Vector2 size;
    public Sprite[] backgroundGenerator;

}
