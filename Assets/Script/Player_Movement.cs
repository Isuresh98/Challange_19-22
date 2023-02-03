using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    [SerializeField] float _jumForce = 10f;
    public int _ScoreCount;
    Rigidbody2D _rbody;
    bool isGround;
    private SpriteRenderer _spriteRender;
    [SerializeField] private GameObject _bulatPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Shoot();

    }
  
    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movemrnt = new Vector2(horizontalInput, 0);
        transform.position += movemrnt * _speed * Time.deltaTime;
    }
    void Jump()
    {
        if (isGround&&Input.GetButtonDown("Jump"))
        {
            _rbody.velocity = Vector2.up * _jumForce * Time.deltaTime;

        }
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_bulatPrefabs, transform.position, Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _ScoreCount += 5;
            Destroy(collision.gameObject);
            _spriteRender.color = Color.gray;
        }
        if (collision.gameObject.CompareTag("DounGround"))
        {
            isGround = true;
            Rigidbody2D DounGround_rBody = collision.gameObject.GetComponent<Rigidbody2D>();

            if(DounGround_rBody != null)
            {
                DounGround_rBody.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
