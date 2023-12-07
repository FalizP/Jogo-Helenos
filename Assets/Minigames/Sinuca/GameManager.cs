using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // make it available globally
    public BallController branca; // instance of the main ball

    [Header("Posição Inicial Bola Branca")]
    [SerializeField] private Vector2 InicialBolaBranca = new(0, -4f);

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
        Instantiate(branca, InicialBolaBranca, Quaternion.identity);
    }
}