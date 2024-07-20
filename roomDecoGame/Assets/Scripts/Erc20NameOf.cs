using UnityEngine;
using ChainSafe.Gaming.Evm.Contracts.BuiltIn;
using ChainSafe.Gaming.UnityPackage;
using Scripts.EVM.Token;

/* This sample script should be copied & placed on the root of an object in a scene.
Change the class name, variables and add any additional changes at the end of the function.
The scripts function should be called by a method of your choosing - button, function etc */

/// <summary>
/// Fetches the name of an ERC20 contract
/// </summary>
public class Erc20NameOf : MonoBehaviour
{
    // Variables
    private string contractAddress = "0x358969310231363CBEcFEFe47323139569D8a88b";

    // Function
    public async void Name()
    {
        var name = await Web3Accessor.Web3.Erc20.GetName(contractAddress);
        SampleOutputUtil.PrintResult(name, "ERC-20", nameof(Erc20Service.GetName));
        // You can make additional changes after this line
    }
}