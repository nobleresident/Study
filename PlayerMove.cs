using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{

    public int jumpPower;
    Rigidbody rigid;
    bool isJump;

    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        isJump = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            isJump = true;
            Debug.Log("isJump? : " + isJump);
        }
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            isJump = false;
            Debug.Log("isJump? : " + isJump);
        }
    }
}
