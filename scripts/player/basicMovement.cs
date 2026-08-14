using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class basicMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float spd = 10f;

    [SerializeField] 
    private float dashSpd = 20f;
    private bool isCooldownDash = false;
    private bool isDashing = false;

    private Vector2 direction = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; //since its a topdown        
    }

    void FixedUpdate()
    {
        // AWSD basic movement
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            
        }
        if (Input.GetKey(KeyCode.A)) direction += Vector2.left;
        if (Input.GetKey(KeyCode.W)) direction += Vector2.up;
        if (Input.GetKey(KeyCode.S)) direction += Vector2.down;
        if (Input.GetKey(KeyCode.D)) direction += Vector2.right;

        if (direction != Vector2.zero) { direction = direction.normalized; } //normalize thing
        
        if (isDashing)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, direction * dashSpd, 5f * Time.fixedDeltaTime);
        } else
        {    
            rb.velocity = direction * spd;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !isCooldownDash)
        {
            Debug.Log("dash");
            isCooldownDash = true;
            isDashing = true;
            StartCoroutine(DashCooldown());
        }
    }
    IEnumerator DashCooldown()
    {
        Debug.Log("Dash cooldown: 2s");
        yield return new WaitForSeconds(0.2f);
        isDashing = false;
        yield return new WaitForSeconds(0.8f);
        Debug.Log("Dash cooldown: 1s");
        yield return new WaitForSeconds(1f);
        Debug.Log("Dash cooldown done");
        isCooldownDash = false;
    }

}
