using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class etapa : MonoBehaviour
{
        public GameObject objetoB;

        void Start()
        {
            // Desliga o "ObjetoB" no início do jogo
            objetoB.SetActive(false);

            // Agenda a ativação do "ObjetoB" após 15 segundos
            Invoke("AtivarObjetoB", 15f);
        }

    void AtivarObjetoB()
    {
            // Liga o "ObjetoB"
            objetoB.SetActive(true);
    }

}
