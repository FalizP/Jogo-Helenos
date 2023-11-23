using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoSc : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private float timer2;
    public float TempoLimite;
    public float TempoLimiteClonar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {

            Destroy(this.gameObject);

        }
    
    
    }

            // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if (timer > TempoLimiteClonar)
        { 
        
            timer = 0;
            shoot();

        }

        if (timer2 > TempoLimite)
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
