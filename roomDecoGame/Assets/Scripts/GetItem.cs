using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class GetItem : MonoBehaviour
{
    private const string mainScene = "testScene";
    private const int cost = 50;
    private int coin;
    [SerializeField]  private GameObject furniture;
    [SerializeField]  private GameObject pattern;
    [SerializeField] private SpriteMask mask;
    [SerializeField] private GameObject PickPanel;
    [SerializeField] private GameObject ResultPanel;
    [SerializeField] private GameObject AlertPanel;
    [SerializeField] private TextMeshProUGUI AlertText;
    [SerializeField] private TextMeshProUGUI CoinText;

    private Color patternColor;
    // Start is called before the first frame update
    void Start()
    {
        coin = PlayerPrefs.GetInt("Coin", 0);
        CoinText.text = coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            coin -= cost;
            CoinText.text = coin.ToString();
            PlayerPrefs.SetInt("Coin", coin);
            PickPanel.SetActive(false);
            ResultPanel.SetActive(true);
        }
        else
        {
            AlertPanel.SetActive(true);
            AlertText.text = "코인이 부족합니다. 현재: " + coin + "코인입니다.";
        }
    }

    public void OnClickAlert()
    {
        AlertPanel.SetActive(false);
    }

    public void OnClickResult()
    {
        ResultPanel.SetActive(false);
        PickPanel.SetActive(true);
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene(mainScene);
    }

    private void LoadFurnitures()
    {
        DirectoryInfo di = new DirectoryInfo(Application.dataPath + "/Resources/Sprites/furniture");
        FileInfo [] files = di.GetFiles();
        int index = UnityEngine.Random.Range(0, files.Length);
        string path = "Sprites/furniture/" + RemoveFileExtension(files[index].Name);
        furniture.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
    }

    private void LoadPatterns()
    {
        DirectoryInfo di = new DirectoryInfo(Application.dataPath + "/Resources/Sprites/pattern");
        FileInfo[] files = di.GetFiles();
        int index = UnityEngine.Random.Range(0, files.Length);

        string path = "Sprites/pattern/" + RemoveFileExtension(files[index].Name);
        pattern.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
    }

    private string RemoveFileExtension(string path)
    {
        return path.Remove(path.IndexOf("."));
    }

    private void MaskPattern()
    {
        Debug.Log(mask);
        mask.sprite = furniture.GetComponent<SpriteRenderer>().sprite;
        pattern.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    private void SetFurnitureColor()
    {
        Color furnitureColor = new(UnityEngine.Random.Range(0, 256)/255f, UnityEngine.Random.Range(0, 256) / 255f, UnityEngine.Random.Range(0, 256) / 255f, UnityEngine.Random.Range(50, 256) / 255f);
        furniture.GetComponent<SpriteRenderer>().color = furnitureColor;
    }

    private void SetPatternColor()
    {
        Color patternColor = new(UnityEngine.Random.Range(0, 256) / 255f, UnityEngine.Random.Range(0, 256) / 255f, UnityEngine.Random.Range(0, 256) / 255f, UnityEngine.Random.Range(50, 256) / 255f);
        pattern.GetComponent<SpriteRenderer>().color = patternColor;
    }
}
