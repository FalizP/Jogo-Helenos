using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{

    [SerializeField]
    public GameObject Portal;

    [SerializeField]
    public SpriteRenderer PortaFechada;

    [SerializeField]
    public Sprite PortaAberta;

    private float tempo = 0;

    // Start is called before the first frame update
    void Start()
    {

        Portal.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        
        if (tempo > 75)
        {
            Portal.SetActive(true);
            PortaFechada.sprite = PortaAberta;

        }



    }
}
