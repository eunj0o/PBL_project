using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestMain : MonoBehaviour
{
    private GameObject prefabTest;
    private const string miniGameScene = "miniGameScene";
    private const string pickItemScene = "randomScene";
    // Start is called before the first frame update

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

    public void OnClickTest()
    {
        ItemControl.control.itemList.Last().iObject.SetActive(true);
    }
}
