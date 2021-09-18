using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private CharacterController cc;
   // private Rigidbody rb;
    private Vector3 movement;
    private float horizontal;
    private float vertical;
    private void Awake()
    {
        cc = GetComponent<CharacterController>();
       // rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
    void Update()
    {
  
    }
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Vertical") * speed;
        vertical = Input.GetAxis("Horizontal") * speed;
        movement = transform.forward * horizontal + transform.right * vertical;
        cc.Move( movement * speed * Time.fixedDeltaTime);
    }
}
