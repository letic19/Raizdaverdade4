using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    Rigidbody2D rb;
    SpriteRenderer sr;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 vel = rb.linearVelocity;
        vel.x = h * speed;
        rb.linearVelocity = vel;


        // Flip sprite
        if (h > 0.1f) sr.flipX = false;
        else if (h < -0.1f) sr.flipX = true;


        // Pulo simples (assume Ground check external ou permitido sempre):
        if (Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}