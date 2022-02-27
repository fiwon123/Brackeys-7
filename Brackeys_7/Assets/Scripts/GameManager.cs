using System;
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

    public GameObject finalImage;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 1; i < currentLevel; i++)
        {
            allMessageDatas.RemoveAt(0);
            allLevelDatas.RemoveAt(0);
        }

        ChatManager.Instance.SetData(allMessageDatas[0]);
    }

    public void StartPuzzle()
    {
        isPuzzleStarted = true;

        WindowSpawner.Instance.SetLevelData(allLevelDatas[0]);
        WindowSpawner.Instance.StartSpawn();
    }

    public void RestartPuzzle()
    {
        if (!WindowSpawner.Instance)
        {
            return;
        }

        WindowSpawner.Instance.FinishSpawn();
        StartPuzzle();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.PlaySoundEffect(SoundEffect.Click);
        }
    }

    public void WinPuzzle()
    {
        SoundManager.Instance.PlaySoundEffect(SoundEffect.Success);
        if (allMessageDatas.Count > 0)
            allMessageDatas.RemoveAt(0);
        if (allLevelDatas.Count > 0)
            allLevelDatas.RemoveAt(0);

        isPuzzleStarted = false;

        WindowSpawner.Instance.FinishSpawn();

        if (allMessageDatas.Count > 0)
        {
            ChatManager.Instance.SetData(allMessageDatas[0]);
            WindowSpawner.Instance.SetLevelData(allLevelDatas[0]);

            currentLevel++;
        }
        else
        {
            //Gatilho de end game
            Debug.Log("End Game");
            StartCoroutine(FinalRoutine());
        }

    }

    IEnumerator FinalRoutine()
    {
        currentLevel++;
        yield return new WaitForSeconds(2f);
        finalImage.SetActive(true);
    }

    public void LosePuzzle()
    {
        isPuzzleStarted = false;
        RestartPuzzle();
    }

}
