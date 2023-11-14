using UnityEngine;

public class MoveIA : MonoBehaviour
{
    [SerializeField] private float speed = -0.05f;

    void Update()
    {
        MoverIA();
        DestruirGameObject();
    }

    void MoverIA()
    {
        transform.position += new Vector3(0, speed, 0);
    }

    void DestruirGameObject()
    {
        if (transform.position.y <= -5.5f)
        {
            Destroy(gameObject);
            MoveCarro.pontos++;
        }
    }
}
