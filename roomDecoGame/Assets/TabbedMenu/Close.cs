using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Close : MonoBehaviour
{
    [SerializeField] private GameObject setting_document;
    private void OnEnable()
    {
        UIDocument setting = GetComponent<UIDocument>();
        VisualElement root = setting.rootVisualElement;
        Button close = root.Q<Button>("close");
        close.RegisterCallback<ClickEvent>(onCloseClick);
    }

    public void onCloseClick(ClickEvent evt)
    {
        setting_document.active = false;
    }
}
