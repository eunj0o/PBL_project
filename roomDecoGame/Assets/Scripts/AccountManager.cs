using ChainSafe.Gaming.UnityPackage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string toAccount = "";
    public void getAccount()
    {
        toAccount = Web3Accessor.Web3.Signer.PublicAddress;
    }

}
