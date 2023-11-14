using UnityEngine;

public class MoveBg : MonoBehaviour
{
    private bool hasInstatiate = false;
    [SerializeField] private float speed = -0.1f;

    void Update()
    {
        transform.position += new Vector3(0, speed, 0);

        if (transform.position.y <= -13f)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y <= -1f)
        {
            if (!hasInstatiate)
            {
                hasInstatiate = true;
                GameObject obj = Instantiate(gameObject, new Vector3(transform.position.x, 11f, transform.position.y), Quaternion.Euler(0, 0, 0));
            }
        }
    }
}
