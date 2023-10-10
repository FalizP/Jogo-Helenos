using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaw : MonoBehaviour
{


    public GameObject bullet;
    public Transform bulletPos;

    public float timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime; 

        if(timer > 4)
        {

            timer = 0;
            shoot();

        }

    }

    void shoot()
    {

        Instantiate(bullet, bulletPos.position, Quaternion.identity);

    }
}
