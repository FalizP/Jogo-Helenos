using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoSc : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private float timer2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if (timer > 2)
        { 
        
            timer = 0;
            shoot();

        }

        if (timer2 > 5)
        {

            timer2 = 0;
            Destroy(this.gameObject);

        }

      

    }

    

    void shoot()
    {

        Instantiate(bullet, bulletPos.position, Quaternion.identity);

    }
}
