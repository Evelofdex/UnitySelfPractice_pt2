using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private float launchSpeed;

    // Start is called before the first frame update
    void Start()
    {
        launchSpeed = 10f;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(start());
    }

    IEnumerator start()
    {
        yield return new WaitForSeconds(2f);
        rb.velocity = Vector2.up.normalized * launchSpeed;
    }
}
