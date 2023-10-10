using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrelaNinja : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public float tempo;
    
    // Start is called before the first frame update
    void Start()
    {

        gameObject.SetActive(false);

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direcction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direcction.x, direcction.y).normalized * force;

        float rot = Mathf.Atan2(-direcction.y, direcction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 45);


    }

    // Update is called once per frame
    void Update()
    {


        
    }


}
