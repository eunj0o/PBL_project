using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Grid에 추가

public class DragWindow : MonoBehaviour, IDragHandler
{
    [SerializeField] private RectTransform dragRectTransform; //Drag Rect Transform  에 Grid  넣기
    [SerializeField] private Canvas canvas;

    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
