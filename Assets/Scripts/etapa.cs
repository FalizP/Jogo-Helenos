using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class etapa : MonoBehaviour
{
        public GameObject objetoB;

        void Start()
        {
            // Desliga o "ObjetoB" no in�cio do jogo
            objetoB.SetActive(false);

            // Agenda a ativa��o do "ObjetoB" ap�s 15 segundos
            Invoke("AtivarObjetoB", 15f);
        }

    void AtivarObjetoB()
    {
            // Liga o "ObjetoB"
            objetoB.SetActive(true);
    }

}
