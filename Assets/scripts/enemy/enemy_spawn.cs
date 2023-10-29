using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
    [SerializeField] int enemypos;
    [SerializeField] int rechargetimer;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("firstspawn");  
    }

    void Update()
    {
        
    }

    IEnumerator firstspawn()
    {
        rechargetimer = Random.Range(2, 10);
        yield return new WaitForSeconds(rechargetimer);
        StartCoroutine("enemyspawn");
    }

    IEnumerator enemyspawn()
    {
        enemypos = 1;
        if (enemypos == 1)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            rechargetimer = Random.Range(2, 10);
            yield return new WaitForSeconds(rechargetimer);
            StartCoroutine("enemyspawn");
        }
        else
        {
            yield return new WaitForSeconds(rechargetimer);
            rechargetimer = Random.Range(2, 10);
            StartCoroutine("enemyspawn");
        }

    }
}
