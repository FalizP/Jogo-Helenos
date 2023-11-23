using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chave : MonoBehaviour
{

    [SerializeField]
    public int chave;

    [SerializeField]
    public GameObject Portal;

    [SerializeField]
    public SpriteRenderer Porta;

    [SerializeField]
    public Sprite PortaAberta;

    //colocar no player

    private void Start()
    {
            
        Portal.SetActive(false);

    }

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

            Portal.SetActive(true);
            Porta.sprite = PortaAberta;

        }

    }

}
