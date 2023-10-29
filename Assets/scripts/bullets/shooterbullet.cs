using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterbullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3((float)(transform.position.x+0.05), transform.position.y, transform.position.z);
    }
        

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
