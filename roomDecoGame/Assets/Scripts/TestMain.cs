using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestMain : MonoBehaviour
{
    public GameObject grid;
    Inventory inventory;
    private GameObject prefabTest;
    private const string miniGameScene = "miniGameScene";
    private const string exchangeScene = "exchangeScene";
    private const string pickItemScene = "randomScene";
    private const string sampleScene = "WebLogin";
    [SerializeField] public int coin = 0;
    [SerializeField] private TextMeshProUGUI CoinText;
    // Start is called before the first frame update
    void Start()
    {
        //ItemControl.control.itemList.Last().iObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        coin = PlayerPrefs.GetInt("Coin", coin);
        CoinText.text = coin.ToString();
    }

    private void Update()
    {
        
    }

    public void OnMiniGameButton()
    {
        if (ItemControl.control.itemList.Any())
        {
            // If itemList has elements, deactivate the last item's GameObject
            ItemControl.control.itemList.Last().iObject.SetActive(false);
        }
        else
        {
            // Handle the case when itemList is empty
            Debug.LogWarning("itemList is empty. Cannot set active to false.");
        }

        // Load the scene
        SceneManager.LoadScene(miniGameScene);
    }

    public void OnExchangeButton()
    {
        if (ItemControl.control.itemList.Any())
        {
            // If itemList has elements, deactivate the last item's GameObject
            ItemControl.control.itemList.Last().iObject.SetActive(false);
        }
        else
        {
            // Handle the case when itemList is empty
            Debug.LogWarning("itemList is empty. Cannot set active to false.");
        }

        // Load the scene
        SceneManager.LoadScene(miniGameScene);
    }

    public void OnPickItemButton()
    {
        if (ItemControl.control.itemList.Any())
        {
            // If itemList has elements, deactivate the last item's GameObject
            ItemControl.control.itemList.Last().iObject.SetActive(false);
        }
        else
        {
            // Handle the case when itemList is empty
            Debug.LogWarning("itemList is empty. Cannot set active to false.");
        }

        // Load the scene
        SceneManager.LoadScene(pickItemScene);
    }
    public void OnPlayButton()
    {

        // Load the scene
        SceneManager.LoadScene(sampleScene);



    }
}
