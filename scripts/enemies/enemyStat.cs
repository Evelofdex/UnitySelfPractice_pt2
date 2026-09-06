using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class enemyStat : MonoBehaviour
{
    private int hp;
    

    [SerializeField] private TextMeshProUGUI hpText;
    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
        hpText.text = hp.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player_bullet"))
        {
            hp--;
            hpText.text = hp.ToString();
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
