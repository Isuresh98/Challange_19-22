using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float _jumpForce = 10f;
    private Rigidbody2D rbody;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Movement();
        Jump();
         
       
    }

    private void Movement()
    { 
        float horizontalInput = Input.GetAxis("Horizontal");
           Vector3 movement = new Vector2(horizontalInput, 0);
          transform.position += movement* speed * Time.deltaTime;
        transform.position += movement* speed * Time.deltaTime;

    }

    void Jump()
    {
       
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rbody.velocity = Vector2.up * _jumpForce * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
