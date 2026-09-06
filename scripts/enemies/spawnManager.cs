using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyObj;

    [SerializeField]
    private GameObject spawnPoint1;
    [SerializeField]
    private GameObject spawnPoint2;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(summonStart());
    }   

    IEnumerator summonStart()
    {
        while (true)
        {    
            Instantiate(enemyObj, spawnPoint1.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            Instantiate(enemyObj, spawnPoint2.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }


    
}
