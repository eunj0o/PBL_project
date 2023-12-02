using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TitleScript : MonoBehaviour, IPointerClickHandler

{
    [SerializeField] private string SceneToLoad;
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject setting_panel;
    [SerializeField] private GameObject setting_document;

    // Start is called before the first frame update
    void Start()
    {
        setting_panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(SceneToLoad);
    } 

    public void settingsBtnClick()
    {
        //var canvasGroup = image.GetComponent<CanvasGroup>();
        //canvasGroup.alpha = 0.1f;
        //canvasGroup.interactable = false;
        //setting_panel.SetActive(true);
        setting_document.active = true;

    }
}
