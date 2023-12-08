using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TitleScript : MonoBehaviour

{
    //[SerializeField] private GameObject image;
    //[SerializeField] private GameObject setting_panel;
    [SerializeField] private GameObject setting_document;

    // Start is called before the first frame update
    void Start()
    {
        //setting_panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void settingsBtnClick()
    {
        //var canvasGroup = image.GetComponent<CanvasGroup>();
        //canvasGroup.alpha = 0.1f;
        //canvasGroup.interactable = false;
        //setting_panel.SetActive(true);
        setting_document.SetActive(true);

    }
}
