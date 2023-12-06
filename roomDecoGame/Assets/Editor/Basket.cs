using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.VersionControl;
#endif
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private GameObject basket;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ToRight()
    {
        spriteRenderer.flipX = false;
        basket.transform.localPosition = new Vector3(4, basket.transform.localPosition.y, basket.transform.localPosition.z);
    }

    public void ToLeft()
    {
        spriteRenderer.flipX = true;
        basket.transform.localPosition = new Vector3(-4, basket.transform.localPosition.y, basket.transform.localPosition.z);
    }
}
