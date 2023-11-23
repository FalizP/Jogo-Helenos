using UnityEngine;

public class CheckColider : MonoBehaviour
{
    public bool isTouched;
    [SerializeField] private string nomeObjPlayer;

    private void Start()
    {
        isTouched = false;
    }

    private void Update()
    {
        float player = GameObject.Find("Player_Doodle").transform.position.y;

        if (transform.position.y - player < -30f)
        {
            Destroy(gameObject);
        }
    }
}
