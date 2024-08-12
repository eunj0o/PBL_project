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
    Slot slot = new Slot();
    public int index = 0;
    public List<ItemInfo> itemDB = new List<ItemInfo>();
    public Slot[] slots;
    public Transform slotHolder;


    private void Start()
    {
        slots = slotHolder.GetComponentsInChildren<Slot>();
        InventoryInit();
        InventoryUI.SetActive(activeInventory);
        
    }

    void Update()
    {
        if (UnityEngine.Input.GetKeyUp(KeyCode.I))
        {
            activeInventory = !activeInventory;
            InventoryUI.SetActive(activeInventory);
            
        }

        furnitureController.FurMove(index);
        furnitureController.FurRotate(index);


    }

    /*
    public void InventoryStatus()
    {
        if (activeInventory == true)
        {
            int j = 0;
            InventoryUI.SetActive(activeInventory);

            for (int i = 0; i < ItemControl.control.itemList.Count; i++)
            {
                if (ItemControl.control.itemList[i].bePlaced == true)
                {
                    //ItemControl.control.itemList[i].slotNum = -1;
                    continue;
                }
                ItemControl.control.itemList[i].iObject.transform.position = grid.transform.GetChild(i).position;
                ItemControl.control.itemList[i].iObject.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
                ItemControl.control.itemList[i].iObject.SetActive(activeInventory);
                //ItemControl.control.itemList[i].slotNum = j;
                //j++;

            }

        }
        else
        {
            for (int i = 0; i < ItemControl.control.itemList.Count; i++)
            {
                if (ItemControl.control.itemList[i].bePlaced == true)
                {
                    //ItemControl.control.itemList[i].slotNum = -1;
                    continue;
                }
                ItemControl.control.itemList[i].iObject.SetActive(activeInventory);
            }
            InventoryUI.SetActive(activeInventory);

        }
    }
    */

    public void InventoryInit()
    {
        int j = 0;

        for (int i = 0; i < ItemControl.control.itemList.Count; i++)
        {
            if (ItemControl.control.itemList[i].bePlaced == false)
            {
                itemDB.Add(slots[i].UpdateSlot(i, j));
                j++;
            }
        }
    }


    /*
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
    */

    public void OnClickSlot()
    {
        index = slot.getIndex();
        itemDB.Remove(ItemControl.control.itemList[index]);
        InventoryInit();
    }

}


