using UnityEngine;

public class GenereteWorld : MonoBehaviour
{
    private float nextY = -5f;
    public GameObject plataforma;

    [Header("Player")]
    [SerializeField] private string nomeObjPlayer;

    void Update()
    {
        Transform playerPos = GameObject.Find(nomeObjPlayer).transform;

        if (playerPos.position.y >= nextY)
        {
            for (int i = 0; i < 15; i++)
            {
                float xx = Random.Range(-2f, 10f);
                float yy = (nextY + (i * 4));
                Instantiate(plataforma, new Vector3(xx, yy, 0), Quaternion.identity);
            }
            nextY += 30f;
        }
    }
}
