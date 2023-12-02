using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ResolutionSetting
{
    private readonly VisualElement root;
    private List<Resolution> resolutions = new List<Resolution>();
    private DropdownField dropDownField;
    private int width;
    private int height;

    public ResolutionSetting(VisualElement root)
    {
        this.root = root;
        dropDownField = root.Q<DropdownField>(name: "resolution");
        dropDownField.RegisterValueChangedCallback(OnChanged);
        InitResolutions();
        SetItems();
    }

    private void InitResolutions()
    {
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRate == 60)
                resolutions.Add(Screen.resolutions[i]);
        }
        resolutions.AddRange(Screen.resolutions);
    }

    private void SetItems()
    {
        foreach (Resolution item in resolutions)
        {
            dropDownField.choices.Add(item.width + "x" + item.height + " " + item.refreshRate + "hz");
        }
    }
    private void OnChanged(ChangeEvent<string> evt)
    {
        string selected = evt.newValue;
        
        /*
         selected 문자열에서 width, height 추출
         */
    }
}
