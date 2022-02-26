using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentLevel = 1;

    [SerializeField]
    List<MessageData> allMessageDatas;
    [SerializeField]
    List<LevelData> allLevelDatas;

    public bool isPuzzleStarted;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < currentLevel; i++)
        {
            allMessageDatas.RemoveAt(0);
            allLevelDatas.RemoveAt(0);
        }

        ChatManager.Instance.SetData(allMessageDatas[0]);
        WindowSpawner.Instance.SetLevelData(allLevelDatas[0]);
    }

    public void StartPuzzle()
    {
        isPuzzleStarted = true;

        WindowSpawner.Instance.StartSpawn();
    }

    public void RestartPuzzle()
    {
        WindowSpawner.Instance.FinishSpawn();
        StartPuzzle();
    }

    public void WinPuzzle()
    {
        allMessageDatas.RemoveAt(0);
        allLevelDatas.RemoveAt(0);

        isPuzzleStarted = false;

        WindowSpawner.Instance.FinishSpawn();

        if (allMessageDatas.Count > 0)
        {
            ChatManager.Instance.SetData(allMessageDatas[0]);
            WindowSpawner.Instance.SetLevelData(allLevelDatas[0]);

            currentLevel++;
        }

    }

    public void LosePuzzle()
    {
        isPuzzleStarted = false;
    }

}
