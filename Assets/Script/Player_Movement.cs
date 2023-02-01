using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public bool isGrounded;
    private Rigidbody2D rbody;
    [SerializeField] SpriteRenderer _srender; 

    [SerializeField] float speed = 10f;
    [SerializeField] float _jumpForce = 10f;
    [SerializeField]private int ScoreCount;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        _srender = GetComponent<SpriteRenderer>();
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
    }//Jump
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ScoreCount += 5;
            Destroy(collision.gameObject);
            _srender.color = Color.grey;
        }

    }//OnCollisionEnter2D
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }//OnCollisionExit2D
}
