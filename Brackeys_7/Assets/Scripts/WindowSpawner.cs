using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowSpawner : MonoBehaviour
{
    [Foldout("Setup", true)]
    [SerializeField]
    private GameObject windowPrefab = default;
    [SerializeField]
    private Transform canvas = default;

    [Foldout("Data Windows", true)]
    [SerializeField]
    private SpawnData[] datas = default;
    [SerializeField]
    private LevelData levelData = default;


    private float screenWidth = default;
    private float screenHeight = default;
    private RangedFloat rangeSpawnX = default;
    private RangedFloat rangeSpawnY = default;

    public Transform successButton;

    public static WindowSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ConfigureRect();
        
    }

    private void ConfigureRect()
    {
        RectTransform rt = (RectTransform)this.transform;
        float width = rt.rect.width;
        float height = rt.rect.height;

        screenWidth = width;
        screenHeight = height;

        rangeSpawnX.Min = 0;
        rangeSpawnX.Max = width;

        rangeSpawnY.Min = 0f;
        rangeSpawnY.Max = height;
    }

    public void SetLevelData(LevelData value)
    {
        levelData = value;
    }

    public void StartSpawn()
    {
        ConfigureRect();
        ClearWindows();

        for (int i = 0; i < levelData.initialCountWindows; i++)
        {
            SpawnWindow();
        }

        successButton.position = transform.GetChild(0).position;
        Vector2 newPosSuccessButton = successButton.localPosition;
        newPosSuccessButton.x += 50f;
        newPosSuccessButton.y += 50f;
        successButton.localPosition = newPosSuccessButton;

        StartCoroutine(SpawnWindowCoroutine(levelData.timeSpawn));
        StartCoroutine(CountDownCoroutine(levelData.timeFinish));
    }

    public void FinishSpawn()
    {
        StopAllCoroutines();
    }

    private IEnumerator CountDownCoroutine(float time)
    {
        yield return new WaitForSeconds(time);

        GameManager.Instance.LosePuzzle();
        FinishSpawn();
    }

    private IEnumerator SpawnWindowCoroutine(RangedFloat time)
    {
        while (GameManager.Instance.isPuzzleStarted) {
            yield return new WaitForSeconds(Random.Range(time.Min, time.Max));
            SpawnWindow();
        }
    }

    [ButtonMethod]
    public void ClearWindows()
    {
        foreach (Transform child in canvas)
        {
            Destroy(child.gameObject);
        }
    }

    [ButtonMethod]
    public void SpawnWindow()
    {
        // Instantiate new Window
        GameObject newWindow = Instantiate(windowPrefab, Vector2.zero, Quaternion.identity, canvas);

        // Generate a data
        int indexRnd = Random.Range(0, datas.Length);
        SpawnData dataRnd = datas[indexRnd];

        // Generate Background
        newWindow.GetComponent<WindowsController>().background.sprite = GenerateBackground(dataRnd);

        // Generate new Size;
        SetNewSize(ref newWindow, ref dataRnd.size);

        // Generate Pos
        newWindow.transform.localPosition = GeneratePos(ref dataRnd.size);
        
    }

    private Sprite GenerateBackground(SpawnData data)
    {
        if (data.backgroundGenerator.Length == 0)
        {
            return null;
        }

        int indexRnd = Random.Range(0, data.backgroundGenerator.Length);
        Sprite newBackground = data.backgroundGenerator[indexRnd];

        return newBackground;
    }

    private void SetNewSize(ref GameObject newWindow, ref Vector2 newSize)
    {
        RectTransform rectTransform = newWindow.GetComponent<RectTransform>();
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newSize.x);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newSize.y);
    }

    private Vector3 GeneratePos(ref Vector2 newSize)
    {
        Vector2 newPos = Vector2.zero;
        newPos.x = Random.Range(rangeSpawnX.Min, rangeSpawnX.Max);

        newPos.y = Random.Range(rangeSpawnY.Min, rangeSpawnY.Max);
        if (isOffScreen(ref newPos, ref newSize, out float offsetX, out float offsetY))
        {
            newPos.x -= offsetX;
            newPos.y -= offsetY;
        }

        return newPos;
    }

    private bool isOffScreen(ref Vector2 newPos, ref Vector2 newSize, out float offsetX, out float ofssetY)
    {
        offsetX = (newPos.x + newSize.x) - screenWidth;
        offsetX = Mathf.Clamp(offsetX, 0, screenWidth);

        ofssetY = (newPos.y + newSize.y) - screenHeight;
        ofssetY = Mathf.Clamp(ofssetY, 0, screenHeight);

        return (offsetX > 0) || (ofssetY > 0);
    }
}

