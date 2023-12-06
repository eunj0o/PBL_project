using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor.VersionControl;
#endif
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void ToRight()
    {
        spriteRenderer.flipX = false;
        player.transform.localPosition = new Vector3(-68, player.transform.localPosition.y, player.transform.localPosition.z);
    }

    public void ToLeft()
    {
        spriteRenderer.flipX = true;
        player.transform.localPosition = new Vector3(68, player.transform.localPosition.y, player.transform.localPosition.z);
    }

    public void Run()
    {
        animator.SetBool("run", true);
    }

    public void StopRun()
    {
        animator.SetBool("run", false);
    }
}
