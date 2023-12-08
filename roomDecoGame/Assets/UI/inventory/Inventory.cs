using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class Inventory : MonoBehaviour
{
    public GameObject InventoryUI;
    public GameObject grid;
    bool activeInventory = false;
    FurnitureController furnitureController = new FurnitureController();
    public int index = 0;
    

    private void Start()
    {
        InventoryUI.SetActive(activeInventory);
    }

    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            InventoryStatus();
            Debug.Log(ItemControl.control.itemList[0].iObject.transform.position);
        }

        furnitureController.FurMove(index);
        

    }


    public void InventoryStatus()
    {
        if (activeInventory == true)
        {
            InventoryUI.SetActive(activeInventory);
            for (int i = 0; i < ItemControl.control.itemList.Count; i++)
            {
                if (ItemControl.control.itemList[i].bePlaced == true)
                {
                    continue;
                }
                ItemControl.control.itemList[i].iObject.transform.position = grid.transform.GetChild(i).position;
                ItemControl.control.itemList[i].iObject.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
                ItemControl.control.itemList[i].iObject.SetActive(activeInventory);

            }

        }
        else
        {
            for (int i = 0; i < ItemControl.control.itemList.Count; i++)
            {
                if (ItemControl.control.itemList[i].bePlaced == true)
                {
                    continue;
                }
                ItemControl.control.itemList[i].iObject.SetActive(activeInventory);
            }
            InventoryUI.SetActive(activeInventory);

        }
    }

    public void OnClickSlot()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        string s_index = name.Substring(6, 1);
        index = Convert.ToInt32(s_index);
        furnitureController.SetIndex(index);
        Debug.Log(index);
        ItemControl.control.itemList[index].iObject.transform.position = new Vector3(400, 300, 90);
        ItemControl.control.itemList[index].iObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        ItemControl.control.itemList[index].bePlaced = !ItemControl.control.itemList[index].bePlaced;


        if (ItemControl.control.itemList[index].bePlaced == true)
        {
            ItemControl.control.itemList[index].iObject.SetActive(true);
            

        }
        else
        {
            

        }
    }

}


