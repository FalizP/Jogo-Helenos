using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SigaPlayer : MonoBehaviour
{
    public float moveSpeed = 3.0f; // Velocidade de movimento do inimigo
    public Transform target; // Transform do jogador que o inimigo deve seguir
    

    private void Update()
    {
        if (target != null)
        {
            // Calcula a direção do jogador em relação ao inimigo
            Vector3 direction = target.position - transform.position;
            direction.Normalize(); // Normaliza o vetor para obter uma direção

            // Move o inimigo na direção do jogador
            transform.Translate(direction * moveSpeed * Time.deltaTime);


        }
    }
}