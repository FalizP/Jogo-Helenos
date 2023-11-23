using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;

    [SerializeField]
    private float velocidadeMovimento;

    [SerializeField]
    private float distanciaMinima;

    [SerializeField]
    private Rigidbody2D rigidbody;

    [SerializeField]    
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float raioVisao;

    [SerializeField]
    private LayerMask LayerAreaVisao;

    [SerializeField]
    private LayerMask LayerIgnorarRaycast;


    // Update is called once per frame
    void Update()
    {
        procurarJogador();
        if(this.alvo != null)
        {
            
            Mover();

        } else {
        
            paraMover();

        }
        

    }

    private void OnDrawGizmos()
    {

        Gizmos.DrawWireSphere(this.transform.position, this.raioVisao);
        if(this.alvo != null)
        {

            Gizmos.DrawLine(this.transform.position, this.alvo.position);

        }
                
    }

    private void procurarJogador()
    {

        Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raioVisao, LayerAreaVisao);
        if (colisor != null)
        {
            Vector2 posicaoAtual = this.transform.position;
            Vector2 posicaoAlvo = colisor.transform.position;
            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;

            RaycastHit2D hit = Physics2D.Raycast(posicaoAtual, direcao, Mathf.Infinity, ~LayerIgnorarRaycast);

            if (hit.transform != null)
            {

                if (hit.transform.CompareTag("Player"))
                {

                    this.alvo = colisor.transform;

                }
                else
                {

                    this.alvo = null;

                }

            }
            else
            {

                this .alvo = null;

            }

        } else { 
        
            this.alvo = null;
        
          }

    }

    private void Mover()
    {


        Vector2 posicaoAlvo = this.alvo.position;
        Vector2 posicaoAtual = this.transform.position;

        float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);
        if (distancia >= this.distanciaMinima)
        {

            Vector2 diracao = posicaoAlvo - posicaoAtual;
            diracao = diracao.normalized;

            this.rigidbody.velocity = (this.velocidadeMovimento * diracao);

            if (this.rigidbody.velocity.x > 0)
            {

                this.spriteRenderer.flipX = false;

            }
            else if (this.rigidbody.velocity.x < 0)
            {

                this.spriteRenderer.flipX = true;
            }

        }
        else
        {

            paraMover();

        }

    }

    private void paraMover()
    {

        this.rigidbody.velocity = Vector2.zero;

    }

}
