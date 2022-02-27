using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelData")]
public class LevelData : ScriptableObject
{
    public int level;
    public bool randomizeCloseButton;
    public int initialCountWindows;
    public RangedFloat timeSpawn;
    public float timeFinish;
}
