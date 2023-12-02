using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestMain : MonoBehaviour
{
    private const string miniGameScene = "miniGameScene";
    private const string pickItemScene = "randomScene";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMiniGameButton()
    {
        SceneManager.LoadScene(miniGameScene);
    }

    public void OnPickItemButton()
    {
        SceneManager.LoadScene(pickItemScene);
    }
}
