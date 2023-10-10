using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndandoPlayer : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rigidBody2D;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Animator anim;


    private void LateUpdate()
    {
            
        Vector2 velocidade = this.rigidBody2D.velocity;

        if(( velocidade.x != 0))
        {

            this.anim.SetBool("Es/Dr", true);

        } else
        {

            this.anim.SetBool("Es/Dr", false);

        }

        if ((velocidade.y > 0))
        {

            this.anim.SetBool("costa", true);

        }
        else
        {

            this.anim.SetBool("costa", false);

        }

        if ((velocidade.y < 0))
        {

            this.anim.SetBool("frente", true);

        }
        else
        {

            this.anim.SetBool("frente", false);

        }

        if (velocidade.x < 0)
        {

            this.spriteRenderer.flipX = false;

        }else if (velocidade.x > 0)
        {

            this.spriteRenderer.flipX = true;
        }

    }


}
