using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chave : MonoBehaviour
{

    public int chave;
    public string TrocaCena;

    //colocar no player

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chave"))
        {

            chave++;
            Destroy(collision.gameObject);

        }
    }

    void Update()
    {
        if (chave >= 3)
        {

            SceneManager.LoadScene(TrocaCena);
        }
    }
}
