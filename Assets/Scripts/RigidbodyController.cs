using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider colider;
    public KeyCode JumpKey;
    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        colider = GetComponent<BoxCollider>();
        if(TryGetComponent(out Rigidbody rbNow))
        {
            rb = rbNow;
        }
        else
        {
            rb = this.gameObject.AddComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Input.GetButtonDown("Jump");
        
        if(isGround == true)
        {

            if(Input.GetKey(JumpKey))
            {
                rb.AddForce(0f, 1f, 0f,ForceMode.Impulse);

            }
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.AddForce(x, 0f, y, ForceMode.Impulse);
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        isGround = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isGround = false;
    }*/
    private void OnCollisionEnter(Collision collision)
    {
        isGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }
}
