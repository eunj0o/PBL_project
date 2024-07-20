using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using static UnityEditor.Progress;
#endif

public class ExchangeItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Goods[] goodsList = new Goods[40];      // = GetCoinItems(?, ?, 40);
        foreach(Goods goods in goodsList)
        {
        //    GameObject goodsItem = Instantiate(item, new Vector3(400, 300, 90), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Goods
{
    public Goods(string name)
    {
        this.name = name;
    }
    public string name;
}
