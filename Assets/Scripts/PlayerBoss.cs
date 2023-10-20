using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoss : MonoBehaviour
{

    [Header("Mini Boss")]
    [SerializeField] private bool miniBoss;

    [SerializeField]
    private Rigidbody2D rigidbody;

    [SerializeField]
    private float velocidadeMovimento;

    [SerializeField]
    private BoxCollider2D playerCollider, boxCollider, boxCollider1;

    

    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector2 direcao = new Vector2(horizontal, vertical);
        this.rigidbody.velocity = direcao * this.velocidadeMovimento;

    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        playerCollider = GetComponent<BoxCollider2D>();

        if (miniBoss)
        {
            boxCollider = GameObject.Find("Box").GetComponent<BoxCollider2D>(); 
            boxCollider1 = GameObject.Find("Box1").GetComponent<BoxCollider2D>();

            Physics2D.IgnoreCollision(playerCollider, boxCollider, true);
            Physics2D.IgnoreCollision(playerCollider, boxCollider1, true);
        }
    }
}
