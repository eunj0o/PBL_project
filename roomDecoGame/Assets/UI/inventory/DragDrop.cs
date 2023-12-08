using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    //item의 Script에 Canvas 끌어다 넣기

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
}

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; //마우스 따라 아이템이 움직임
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}

/*
 * item에 Add Component - Canvas Group 추가
 * Alpha = 1 , Interactable 체크 , Blocks Raycasts 체크 , Ignore~ 체크 노노 
 * slot.cs 에 넣을 코드
1. 
using UnityEngine.EventSystems;

2.
MonoBehaviour  옆에 , IDropHandler

3.
public void OnDrop(PointerEventData eventData)
{
    Debug.Log("OnDrop");
    if (eventData.pointerDrag != null)
    {
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
 */
