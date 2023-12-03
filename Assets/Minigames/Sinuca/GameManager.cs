using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // make it available globally
    public BallController branca; // instance of the main ball

    private void Awake()
    {
        instance = this; // load instance before anything else is loaded
    }

    void Start()
    { // spawn the first player
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {   // instantiate a new BallController object
        Instantiate(branca, Vector2.zero, Quaternion.identity);
    }
}