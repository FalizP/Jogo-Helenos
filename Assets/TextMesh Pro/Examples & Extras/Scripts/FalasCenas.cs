using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FalasCenas : MonoBehaviour
{

    private float tempo;
    private Animator anima;
    public GameObject GameObject;
    private float contador = 1;
    public int fase;

    // Start is called before the first frame update
    void Start()
    {

        anima = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        tempo += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (tempo > 18)
            {
                contador = contador + 1;
                anima.SetFloat("Fala", contador);
                GameObject.GetComponent<Animator>().SetFloat("Cena", contador);

            }
        
        }

        if(contador > 4)
        {

            SceneManager.LoadScene(fase);

        }

    }
}
