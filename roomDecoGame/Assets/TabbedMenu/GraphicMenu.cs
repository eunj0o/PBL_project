using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GraphicSetting : MonoBehaviour
{
    private ResolutionSetting resolutionSetting;
    // Start is called before the first frame update
    private void OnEnable()
    {
        UIDocument setting = GetComponent<UIDocument>();
        VisualElement root = setting.rootVisualElement;
        resolutionSetting = new(root);
    }

    
}
