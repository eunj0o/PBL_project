using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Pool;

public class ItemControl : MonoBehaviour
{
    public static ItemControl control;

    public List<ItemInfo> itemList = new List<ItemInfo>();

    // Update is called once per frame
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(control == null)
        {
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
    }

}

public class ItemInfo
{
    public ItemInfo(bool bePlaced, string id, GameObject iObject)
    {
        this.bePlaced = bePlaced;
        this.id = id;
        this.iObject = iObject;
    }
    public bool bePlaced;
    public Vector3 position;
    public Vector3 rotation;
    public string id;
    public GameObject iObject;
}