using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowSpawner : MonoBehaviour
{

    [Header("Setup")]
    [SerializeField]
    private GameObject windowPrefab = default;
    [SerializeField]
    private Transform canvas = default;
    [SerializeField]
    private int screenWidth = 1280;
    [SerializeField]
    private int screenHeight = 720;

    [Foldout("Configs", true)]
    [SerializeField]
    private Vector2[] sizeGenerator = default;
    [SerializeField]
    private Sprite[] backgroundGenerator = default;
    [SerializeField]
    private RangedFloat rangeSpawnX = default;
    [SerializeField]
    private RangedFloat rangeSpawnY = default;


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

        // Generate Background
        newWindow.GetComponent<Image>().sprite = GenerateBackground();

        // Generate new Size;
        Vector2 newSize = GenerateSize();
        SetNewSize(ref newWindow, ref newSize);

        // Generate Pos
        newWindow.transform.position = GeneratePos(ref newSize);
        
    }

    private Sprite GenerateBackground()
    {
        if (backgroundGenerator.Length == 0)
        {
            return null;
        }

        int indexRnd = Random.Range(0, backgroundGenerator.Length);
        Sprite newBackground = backgroundGenerator[indexRnd];

        return newBackground;
    }

    private void SetNewSize(ref GameObject newWindow, ref Vector2 newSize)
    {
        RectTransform rectTransform = newWindow.GetComponent<RectTransform>();
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newSize.x);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newSize.y);
    }

    private Vector2 GenerateSize()
    {
        if (sizeGenerator.Length == 0)
        {
            return Vector2.zero;
        }

        int indexRnd = Random.Range(0, sizeGenerator.Length);
        Vector2 newSize = sizeGenerator[indexRnd];

        return newSize;
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

