using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterContrller : MonoBehaviour
{
    public float speed;

    private CharacterController _characterController;

    public float _yvelocity;

    [SerializeField] private float gravity = 1;

    public float jumpheight = 1;

    public bool hasJump = false;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        Vector3 velocity = move * speed;

        if(Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _yvelocity = jumpheight;
            hasJump = true;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && hasJump)
            {
                hasJump = false;
            }
                _yvelocity -= gravity;
        }

        
        velocity.y = _yvelocity;

        _characterController.Move(velocity * Time.deltaTime);
    }
}
