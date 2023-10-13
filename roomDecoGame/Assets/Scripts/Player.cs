using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= moveTo;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform .position += moveTo;
        }
    }
}
