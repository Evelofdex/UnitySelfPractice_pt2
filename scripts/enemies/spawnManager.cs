using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{

    [SerializeField] private GameObject enemyObj;

    [SerializeField] private GameObject[] spawnPoints;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(summonStart());
    }   

    IEnumerator summonStart()
    {
        while (true)
        {    
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyObj, spawnPoints[randomIndex].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.5f, 3f)); 
        }
    }


    
}
