using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class FurnitureController : MonoBehaviour
{
    int index = 0;
    private int furSpeed = 30;
    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //FurMove();
        FurRotate();
    }

    public void SetIndex(int _index)
    {
        index = _index;
    }
    public void FurMove(int _index)
    {
        if (Input.GetKey(KeyCode.D))
        {
            ItemControl.control.itemList[index].iObject.transform.Translate(new Vector3(-furSpeed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            ItemControl.control.itemList[index].iObject.transform.Translate(new Vector3(furSpeed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.W))
        {
            ItemControl.control.itemList[index].iObject.transform.Translate(new Vector3(0, furSpeed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            ItemControl.control.itemList[index].iObject.transform.Translate(new Vector3(0, -furSpeed * Time.deltaTime, 0));
        }
    }

    void FurRotate()
    {
        Vector3 flipMove = Vector3.zero;
        if (Input.GetKey(KeyCode.Q))
        {
            flipMove = Vector3.one;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rend.flipX = true;
        }
    }
}
