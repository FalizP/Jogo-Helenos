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
            // Calcula a dire��o do jogador em rela��o ao inimigo
            Vector3 direction = target.position - transform.position;
            direction.Normalize(); // Normaliza o vetor para obter uma dire��o

            // Move o inimigo na dire��o do jogador
            transform.Translate(direction * moveSpeed * Time.deltaTime);


        }
    }
}