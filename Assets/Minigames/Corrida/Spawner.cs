using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject inimigo;
    private float timer = 0f;

    [Header("Timer")]
    [SerializeField] private float tempoProximoCarro = 1f;

    void Start()
    {
        transform.position = new Vector3(1, 14, 1);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= tempoProximoCarro)
        {
            timer = 0f;
            SpawnarInimigo();
        }
    }

    void SpawnarInimigo()
    {
        Instantiate(inimigo, new Vector3(Random.Range(-3.50f, 3.90f), transform.position.y, 1), Quaternion.Euler(0, 0, 180));
    }

    
}
