using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class basicMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float spd = 10f;

    private Vector2 direction = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; //since its a topdown        
    } 

    void FixedUpdate()
    {
        direction = Vector2.zero;

        // AWSD basic movement
        if (Input.GetKey(KeyCode.A)) direction += Vector2.left;
        if (Input.GetKey(KeyCode.W)) direction += Vector2.up;
        if (Input.GetKey(KeyCode.S)) direction += Vector2.down;
        if (Input.GetKey(KeyCode.D)) direction += Vector2.right;

        if (direction != Vector2.zero) { direction = direction.normalized; } //normalize thing
        rb.velocity = direction * spd;
    }

}
