using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class enemy_followPlayer : MonoBehaviour
{
    private playerStats playerStat;
    private GameObject player;
    private Rigidbody2D rb;

    [SerializeField]
    private float spd = 5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStat = player.GetComponent<playerStats>();
        rb = GetComponent<Rigidbody2D>();
        rb.mass = 0f;
    }

    // Update is called once per frame
    private void FixedUpdate() 
    {
        Vector2 targetPos = Vector2.MoveTowards(transform.position, player.transform.position, spd * Time.fixedDeltaTime);
        rb.MovePosition(targetPos);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStat.hp -= 10;
            Debug.Log("player hp: " + playerStat.hp);
            Destroy(gameObject);
        }

        if (collision.CompareTag("player_bullet")){
            Destroy(gameObject);
        }
    }
}
