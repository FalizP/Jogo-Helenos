using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    private Vector3 nextBodyPos;
    private int waitUps;

    void Start()
    {
        nextBodyPos = transform.position;
    }

    public void SetTarget(Vector3 position)
    {
        if (waitUps> 0)
        {
            waitUps--;
            return;
        }

        nextBodyPos = position;
    }

    public void WaitHeadUpdates(int value)
    {
        waitUps = value;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextBodyPos, SnakeController.speed * Time.deltaTime);
    }
}
