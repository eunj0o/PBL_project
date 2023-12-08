using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseClick : MonoBehaviour
{
    public string LoadScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (LoadScene == "miniGameScene" | LoadScene == "randomScene")
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
            SceneManager.LoadScene(LoadScene);
        }
        else
        {
            SceneManager.LoadScene(LoadScene);
        }
    }
}
