using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
    Vector3 movement = new Vector2(horizontalInput, 0);
    transform.position += movement* speed * Time.deltaTime;
        transform.position += movement* speed * Time.deltaTime;
    }
}
