using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class paddle_basicMove : MonoBehaviour
{

    
    private Rigidbody2D rb;
    private float currentY;

    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentY = transform.position.y;

        moveSpeed = 2000f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = new Vector2(transform.position.x, currentY);

        if (Input.GetKey(KeyCode.A)) direction += Vector2.left;
        if (Input.GetKey(KeyCode.D)) direction += Vector2.right;

        rb.velocity = direction * moveSpeed * Time.deltaTime;
    }
}
