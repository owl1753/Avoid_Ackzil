using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float moveInput;
    public float moveSpeed;
    public float drag;
    public float jumpForce;
    public bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector2.right * moveInput * moveSpeed);
        if (rb.velocity.x != 0)
        {
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, drag), rb.velocity.y);
        }
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isGround = false;
        }
    }
    void OnTriggerEnter2D(Collider2D cd)
    {
        if (cd.CompareTag("Ground"))
        {
            isGround = true;
        }
        if (cd.CompareTag("Obstacle"))
        {
            Debug.Log("죽음");
        }
    }
}
