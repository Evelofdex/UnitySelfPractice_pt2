using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField]
    private float spd;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = 0f;
        spd = 0.5f;
        rb.AddForce(transform.up * spd, ForceMode2D.Impulse);
        StartCoroutine(deleteBullet());
    }

    IEnumerator deleteBullet()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
}
