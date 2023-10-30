using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanterna : MonoBehaviour
{
    public Vector3 scaleIncrease = new Vector3(); // Aumento de escala desejado
    public GameObject objectToScale; // Objeto que você deseja escalar

    // Detecta quando o jogador colide com o objeto coletável
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Certifique-se de que o jogador colidiu com o objeto
        {
            // Aumenta a escala do objeto desejado
            objectToScale.transform.localScale += scaleIncrease;

            // Desativa o objeto coletável (pode ser destruído ou desativado)
            gameObject.SetActive(false);
        }
    }
}
