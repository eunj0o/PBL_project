using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }
}
