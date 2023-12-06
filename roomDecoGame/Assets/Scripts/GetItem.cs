using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GetItem : MonoBehaviour
{
    private const string mainScene = "testScene";
    private const int cost = 0;     //50
    private int coin;
    [SerializeField] private GameObject item;
    [SerializeField]  private GameObject furniture;
    [SerializeField]  private GameObject pattern;
    [SerializeField] private SpriteMask mask;
    [SerializeField] private GameObject PickPanel;
    [SerializeField] private GameObject ResultPanel;
    [SerializeField] private GameObject AlertPanel;
    [SerializeField] private GameObject PickConfirmButton;
    [SerializeField] private TextMeshProUGUI AlertText;
    [SerializeField] private TextMeshProUGUI CoinText;
    [SerializeField] private int furnitureCount;
    [SerializeField] private int patternCount;
    private bool isCaptured = false;
    private int furnitureIndex = 0;
    private int patternIndex = 0;
    private string furnitureColorCode = "255_255_255_255";
    private string patternColorCode = "255_255_255_255";
    private string itemId;

    private Color patternColor;
    // Start is called before the first frame update
    void Start()
    {
        coin = PlayerPrefs.GetInt("Coin", 0);
        CoinText.text = coin.ToString();
    }

    // Update is called once per frame

    public void makePrefab()
    {
        /*
        #if UNITY_EDITOR
        string localPath = "Assets/Resources/Prefabs/" + itemId + ".prefab";
        // Make sure the file name is unique, in case an existing Prefab has the same name.
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        // Create the new Prefab and log whether Prefab was saved successfully.
        bool prefabSuccess;
        PrefabUtility.SaveAsPrefabAssetAndConnect(item, localPath, InteractionMode.UserAction, out prefabSuccess);
        #endif
        */
        GameObject newItem = Instantiate(item, new Vector3(0,0,90), Quaternion.identity);
        DontDestroyOnLoad(newItem);
        newItem.SetActive(false);
        ItemControl.control.itemList.Add(new ItemInfo(false, itemId, newItem));
    }
    public void OnClickPick()
    {
        if (coin >= cost)
        {
                LoadFurnitures();
                LoadPatterns();
                MaskPattern();
                SetFurnitureColor();
                SetPatternColor();

            itemId = furnitureIndex.ToString() + "_" + furnitureColorCode + "-" + patternIndex + "_" + patternColorCode;
            coin -= cost;
            CoinText.text = coin.ToString();
            PlayerPrefs.SetInt("Coin", coin);
            PickPanel.SetActive(false);
            ResultPanel.SetActive(true);
            
            furniture.transform.localScale = new Vector3(60f, 60f, 60f);
            pattern.transform.localScale = new Vector3(60f, 60f, 60f);
            mask.transform.localScale = new Vector3(60f, 60f, 60f);
            item.SetActive(true);
            makePrefab();
            PickConfirmButton.SetActive(false);
            isCaptured = true;
        //    Capture();
            StartCoroutine(ShowResult());
        }
        else
        {
            AlertPanel.SetActive(true);
            AlertText.text = "코인이 부족합니다. 현재: " + coin + "코인입니다.";
        }
    }

    private IEnumerator ShowResult()
    {
        while (!isCaptured)
        {
            yield return new WaitForSeconds(0.1f);
        }
        furniture.transform.localScale = new Vector3(30f, 30f, 30f);
        pattern.transform.localScale = new Vector3(30f, 30f, 30f);
        mask.transform.localScale = new Vector3(30f, 30f, 30f);
        PickConfirmButton.SetActive(true);
    }

    private void Capture()
    {
        isCaptured = false;
        string path = Application.dataPath + "/Thumbnails/" + itemId + ".png";
        StartCoroutine(CoCapture(path));
    }

    private IEnumerator CoCapture(string path)
    {
        if (path == null)
        {
            yield break;
        }

        // ReadPixels을 하기 위해서 쉬어줌
        yield return new WaitForEndOfFrame();

        Rect rect = new Rect(0f, 0f, Screen.width, Screen.height);
        Texture2D texture = Capture(Camera.main, rect);

        byte[] bytes = texture.EncodeToPNG();
        System.IO.File.WriteAllBytes(path, bytes);
        isCaptured = true;
    }

    private Texture2D Capture(Camera camera, Rect pRect)
    {
        Texture2D capture;
        CameraClearFlags preClearFlags = camera.clearFlags;
        Color preBackgroundColor = camera.backgroundColor;
        {
            camera.clearFlags = CameraClearFlags.SolidColor;

            camera.backgroundColor = Color.black;
            camera.Render();
            Texture2D blackBackgroundCapture = CaptureView(pRect);

            camera.backgroundColor = Color.white;
            camera.Render();
            Texture2D whiteBackgroundCapture = CaptureView(pRect);

            for (int x = 0; x < whiteBackgroundCapture.width; ++x)
            {
                for (int y = 0; y < whiteBackgroundCapture.height; ++y)
                {
                    Color black = blackBackgroundCapture.GetPixel(x, y);
                    Color white = whiteBackgroundCapture.GetPixel(x, y);
                    if (black != Color.clear)
                    {
                        whiteBackgroundCapture.SetPixel(x, y, GetColor(black, white));
                    }
                }
            }

            whiteBackgroundCapture.Apply();
            capture = whiteBackgroundCapture;
            Object.DestroyImmediate(blackBackgroundCapture);
        }
        camera.backgroundColor = preBackgroundColor;
        camera.clearFlags = preClearFlags;
        return capture;
    }

    private Color GetColor(Color black, Color white)
    {
        float alpha = GetAlpha(black.r, white.r);
        return new Color(
            black.r / alpha,
            black.g / alpha,
            black.b / alpha,
            alpha);
    }

    private float GetAlpha(float black, float white)
    {
        return 1 + black - white;
    }

    private Texture2D CaptureView(Rect rect)
    {
        Texture2D captureView = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.ARGB32, false);
        captureView.ReadPixels(rect, 0, 0, false);
        return captureView;
    }

    public void OnClickAlert()
    {
        AlertPanel.SetActive(false);
    }

    public void OnClickResult()
    {
        item.SetActive(false);
        ResultPanel.SetActive(false);
        PickPanel.SetActive(true);
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene(mainScene);
    }

    private void LoadFurnitures()
    {
        int index = UnityEngine.Random.Range(0, furnitureCount);
        string path = "Sprites/furniture/" + index.ToString();
        furniture.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
    }

    private void LoadPatterns()
    {
        int index = UnityEngine.Random.Range(0, furnitureCount);
        string path = "Sprites/pattern/" + index.ToString();
        pattern.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
    }

    private void MaskPattern()
    {
        Debug.Log(mask);
        mask.sprite = furniture.GetComponent<SpriteRenderer>().sprite;
        pattern.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    private void SetFurnitureColor()
    {
        int r = UnityEngine.Random.Range(0, 256);
        int g = UnityEngine.Random.Range(0, 256);
        int b = UnityEngine.Random.Range(0, 256);
        int a = UnityEngine.Random.Range(50, 256);
        Color furnitureColor = new(r / 255f, g / 255f, b / 255f, a / 255f);
        furnitureColorCode = r.ToString() + "_" + g.ToString() + "_" + b.ToString() + "_" + a.ToString();
        furniture.GetComponent<SpriteRenderer>().color = furnitureColor;
    }

    private void SetPatternColor()
    {
        int r = UnityEngine.Random.Range(0, 256);
        int g = UnityEngine.Random.Range(0, 256);
        int b = UnityEngine.Random.Range(0, 256);
        int a = UnityEngine.Random.Range(50, 256);
        Color patternColor = new(r / 255f, g / 255f, b / 255f, a / 255f);
        patternColorCode = r.ToString() + "_" + g.ToString() + "_" + b.ToString() + "_" + a.ToString();
        pattern.GetComponent<SpriteRenderer>().color = patternColor;
    }
}
