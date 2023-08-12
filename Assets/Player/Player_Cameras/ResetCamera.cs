using UnityEngine;

public class ResetCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, -1);
    }
}
