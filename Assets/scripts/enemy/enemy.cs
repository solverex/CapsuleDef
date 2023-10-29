using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.enemydead();
        }
        transform.position = new Vector3((float)(transform.position.x-0.005), transform.position.y, transform.position.z);
    }
        

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            health = health - 5;
        }

        if(collision.gameObject.tag == "playershot")
        {
            health = health - 2;
        }

        if(collision.gameObject.tag == "rapidbul")
        {
            health = health - 1;
        }

        if(collision.gameObject.tag == "blastershot")
        {
            health = health - 20;
        }

        if(collision.gameObject.tag == "base")
        {
            Destroy(gameObject);
            GameManager.instance.healthloss();
        }
    }
}

