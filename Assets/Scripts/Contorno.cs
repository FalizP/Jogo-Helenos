using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contorno : MonoBehaviour
{
    // Referência ao componente SpriteRenderer
    private SpriteRenderer spriteRenderer;

    // Cor padrão
    private Color corPadrao = new Color(0.8314f, 0.8314f, 0.8314f); // Cor D4D4D4
    // Cor ao colidir com a TAG "Jogador"
    private Color corAoColidir = Color.white; // Cor FFFFFF

    // Inicialização
    void Start()
    {
        // Obtém a referência ao componente SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Define a cor padrão no início
        spriteRenderer.color = corPadrao;
    }

    // Verifica colisões
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se a colisão envolve o objeto com a TAG "Jogador"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Muda a cor ao colidir com o jogador
            spriteRenderer.color = corAoColidir;
        }
    }

    // Reseta a cor ao sair da colisão
    void OnCollisionExit2D(Collision2D collision)
    {
        // Verifica se a colisão envolve o objeto com a TAG "Jogador"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Volta para a cor padrão ao sair da colisão
            spriteRenderer.color = corPadrao;
        }
    }
}
