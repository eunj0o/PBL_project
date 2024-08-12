using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image itemIcon;
    public GameObject grid;

    public ItemInfo UpdateSlot(int i, int j)
    {
        GameObject temp = Instantiate(ItemControl.control.itemList[i].iObject);
        temp.transform.SetParent(grid.transform.GetChild(j));
        return ItemControl.control.itemList[i];
    }
    public void RemoveSlot(int i)
    {
        
    }

    public int getIndex()
    {
        return transform.GetSiblingIndex();
    }
}
