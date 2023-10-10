using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnjoSc : MonoBehaviour
{
    public float speed;
    private Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);

    }
}
