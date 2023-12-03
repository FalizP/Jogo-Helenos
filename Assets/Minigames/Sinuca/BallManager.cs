using UnityEngine;

public class BallManaeger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    { // when an object enters
        if (collision.tag == "Ball")
        { // if it's an enemy ball destroy it
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Player")
        { // if it's the player destroy it and respawn
            GameManager.instance.SpawnPlayer();
            Destroy(collision.gameObject);
        }
    }
}