using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_decay1 : MonoBehaviour
{
    [SerializeField] int health = 10;
    // Start is called before the first frame update
    void Awake()
    {
        health = 10;
        StartCoroutine("decay");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if(transform.position.x < 3)
            {
                Destroy(gameObject);
                GameManager.instance.towerdestroyed1();
            }

        }
    }

    IEnumerator decay()
    {
        health--;
        yield return new WaitForSeconds(1);
        StartCoroutine("decay");
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
            GameManager.instance.towerdestroyed1();
        }
    }
}
