using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjetoVoador : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public float tempo;
    public float Proximo;
    public float rota��o;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direcction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direcction.x, direcction.y).normalized * force;

        float rot = Mathf.Atan2(-direcction.y, -direcction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + rota��o);

        
    }

    // Update is called once per frame
    void Update()
    {
        Proximo += Time.deltaTime;
        if (Proximo > tempo) 
        {

            Destroy(gameObject);

        }

    }
}
