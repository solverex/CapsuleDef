using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_fire : MonoBehaviour
{
    public GameObject shooterbullet;
    public Transform shootertower;
    [SerializeField] float firerate;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("shoot");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator shoot()
    {
        Instantiate(shooterbullet, shootertower.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(firerate);
        StartCoroutine("shoot");
    }
}
