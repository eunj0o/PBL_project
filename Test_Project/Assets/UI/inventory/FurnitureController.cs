using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureController : MonoBehaviour
{
    private int furSpeed = 30;
    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        FurMove();
        FurRotate();
    }

    void FurMove()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(-furSpeed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(furSpeed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, furSpeed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -furSpeed * Time.deltaTime, 0));
        }
    }

    void FurRotate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            rend.flipX = false;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rend.flipX = true;
        }
    }
}
