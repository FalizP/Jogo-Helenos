using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camadas : MonoBehaviour
{

    public GameObject area;
    public GameObject area2;
    public Transform player;

    public float minX;
    public float maxX;
    public float minX2;
    public float maxX2;

    public float minY;
    public float maxY;
    public float minY2;
    public float maxY2;

    private void Update()
    {
        // Verifica a posição do objeto a cada frame
        Vector2 objectPosition = transform.position;

        // Verifica se o objeto está dentro da área
        if (objectPosition.x >= minX && objectPosition.x <= maxX && objectPosition.y >= minY && objectPosition.y <= maxY)
        {
            gameObject.GetComponent<Renderer>().sortingOrder = area.GetComponent<Renderer>().sortingOrder - 1;
        }
        if (objectPosition.x >= minX2 && objectPosition.x <= maxX2 && objectPosition.y >= minY2 && objectPosition.y <= maxY2)
        {
            gameObject.GetComponent<Renderer>().sortingOrder = area2.GetComponent<Renderer>().sortingOrder - 1;
        }
        else
        {

            achaPlayer();

        }

        void achaPlayer()
        {
            if (player.transform.position.y < transform.position.y)
            {
                // Se o objeto "Player" estiver abaixo do objeto "Box" no eixo Y
                gameObject.GetComponent<Renderer>().sortingOrder = -2; // Define a ordem na camada para -1
            }
            else
            {
                // Se o objeto "Player" estiver acima do objeto "Box" no eixo Y
                gameObject.GetComponent<Renderer>().sortingOrder = 2; // Define a ordem na camada para 1
            }
        }
    }

}

