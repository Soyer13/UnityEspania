using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour
{
    private Rigidbody rb;

    public KeyCode JumpKey;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
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
        if(Input.GetKey(JumpKey))
        {
            rb.AddForce(0f, 1f, 0f,ForceMode.Impulse);

        }
    }
}
