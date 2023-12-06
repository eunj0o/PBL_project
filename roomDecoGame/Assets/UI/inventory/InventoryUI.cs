using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using System.Windows.Forms;

public class InventoryUI : MonoBehaviour
{
    private const string pickItemScene = "randomScene";
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
        if (Input.GetKeyDown(KeyCode.L))
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

        for (int i = 0; i < ItemControl.control.itemList.Count; i++)
        {
            //slots[i].item.control.itemList = inven.items[i];
            slots[i].UpdateSlotUI();
        }
    }
}
