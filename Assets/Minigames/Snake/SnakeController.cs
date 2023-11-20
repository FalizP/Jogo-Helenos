using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Net.Sockets;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private Vector3 target;
    [SerializeField] private Vector3 saveDir;

    [Header("Cobrinha")]
    [SerializeField] private Transform bodyPrefab;
    [SerializeField] private List<Transform> childList;

    [Header("Maça")]
    [SerializeField] private Transform applePrefab;
    [SerializeField] private Transform appleInGame;

    public static float speed;

    void Start()
    {
        speed = 5;

        target = transform.position;
        saveDir = Vector3.up;

        appleInGame = SpawnApple();
    }

    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (dir.x != 0)
        {
            saveDir = Vector3.right * dir.x;
        }
        if (dir.y != 0)
        {
            saveDir = Vector3.up * dir.y;
        }

        if (transform.position == target)
        {
            target += saveDir;

            PositionCheck();
            SetNewTarget();
        }
    }

    private void PositionCheck()
    {
        if (target.x >= 10 || target.x <= -10 || target.y > 6 || target.y < -6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        foreach (Transform t in childList)
        {
            if (target == t.position)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (appleInGame != null && transform.position == appleInGame.position)
        {
            Destroy(appleInGame.gameObject);

            Transform novoBlocoDoCorpo = Instantiate(bodyPrefab, transform.position, Quaternion.identity);
            novoBlocoDoCorpo.GetComponent<SnakeBody>().WaitHeadUpdates(childList.Count);


            childList.Add(novoBlocoDoCorpo);
            appleInGame = SpawnApple();

            speed += 0.1f;
        }
    }

    private Transform SpawnApple()
    {
        return Instantiate(applePrefab, new Vector3(Random.Range(-9, -9), Random.Range(-5, 5), 0), Quaternion.identity);
    }

    private void SetNewTarget()
    {
        if (childList.Count > 0)
        {
            childList[0].GetComponent<SnakeBody>().SetTarget(transform.position);

            for (int a = childList.Count - 1; a > 0; a--)
            {
                Vector3 p = new Vector3(Mathf.RoundToInt(childList[a - 1].position.x), Mathf.RoundToInt(childList[a - 1].position.y), 0);
                childList[a].GetComponent<SnakeBody>().SetTarget(p);
            }
        }
    }
}
