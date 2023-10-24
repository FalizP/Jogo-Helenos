using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoLabirinto : MonoBehaviour
{

    [SerializeField] Transform Target;

    NavMeshAgent agent;

    // Start is called before the first frame update
    private void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }

    // Update is called once per frame
    private void Update()
    {
        
        agent.SetDestination(Target.position);

    }
}
