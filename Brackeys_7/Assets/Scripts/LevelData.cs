using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelData")]
public class LevelData : MonoBehaviour
{
    public int level;
    public bool isCloseRandom;
    public int initialCountWindows;
    public RangedFloat timeSpawn;
    public float timeFinish;
}
