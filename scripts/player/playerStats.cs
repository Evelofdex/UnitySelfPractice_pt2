using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpCounter;
    public int hp;
    
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
    }

    void Update()
    {
        hpCounter.text = "HP: " + hp;
        if (hp <= 0)
        {
            SceneManager.LoadScene("gameOver");
        }
    }
}
