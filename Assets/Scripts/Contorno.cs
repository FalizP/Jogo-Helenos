using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contorno : MonoBehaviour
{
    // Refer�ncia ao componente SpriteRenderer
    private SpriteRenderer spriteRenderer;

    // Cor padr�o
    private Color corPadrao = new Color(0.8314f, 0.8314f, 0.8314f); // Cor D4D4D4
    // Cor ao colidir com a TAG "Jogador"
    private Color corAoColidir = Color.white; // Cor FFFFFF

    // Inicializa��o
    void Start()
    {
        // Obt�m a refer�ncia ao componente SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Define a cor padr�o no in�cio
        spriteRenderer.color = corPadrao;
    }

    // Verifica colis�es
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se a colis�o envolve o objeto com a TAG "Jogador"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Muda a cor ao colidir com o jogador
            spriteRenderer.color = corAoColidir;
        }
    }

    // Reseta a cor ao sair da colis�o
    void OnCollisionExit2D(Collision2D collision)
    {
        // Verifica se a colis�o envolve o objeto com a TAG "Jogador"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Volta para a cor padr�o ao sair da colis�o
            spriteRenderer.color = corPadrao;
        }
    }
}
