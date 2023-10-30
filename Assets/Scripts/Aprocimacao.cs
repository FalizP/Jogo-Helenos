using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aprocimacao : MonoBehaviour
{
    public Transform player; // Insira o jogador ou o objeto de referência aqui
    public float proximityDistance = 5.0f;
    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        audioSource = GetComponent < AudioSource>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < proximityDistance && !isPlaying)
        {
            audioSource.loop = true;
            audioSource.Play();
            isPlaying = true;
        }
        else if (distance >= proximityDistance && isPlaying)
        {
            audioSource.loop = false;
            isPlaying = false;
        }
    }
}

