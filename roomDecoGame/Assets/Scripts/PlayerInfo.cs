using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI playerAccount;
    void Start()
    {
        string account = PlayerPrefs.GetString("Account");
        playerAccount.text = account;
        print(account);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
