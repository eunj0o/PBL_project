using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Windows.Forms;

public class InventoryUI : MonoBehaviour
{
    Inventory inven;
    public GameObject inventoryPanel; //inventoryPanel에는 InventoryUI오브젝트를 담음
    bool activeInventory = false;

    public Slot[] slots;
    public Transform slotHolder;
    private void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven.onSlotCountChange += SlotChange;
        inven.onChangeItem += RedrawSlotUI;
        inventoryPanel.SetActive(activeInventory);
    }

    private void SlotChange(int val)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inven.SlotCnt)
                slots[i].GetComponent<Button>().interactable = true;
            else
                slots[i].GetComponent<Button>().interactable = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }

    public void AddSlot()
    {
        inven.SlotCnt = inven.SlotCnt + 4;
    }

    void RedrawSlotUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }

        for (int i = 0; i < inven.items.Count; i++)
        {
            slots[i].item = inven.items[i];
            slots[i].UpdateSlotUI();
        }
    }
}