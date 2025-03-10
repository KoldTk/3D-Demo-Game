using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    public Transform playerfoot;
    public Animator anim;
    public NavMeshAgent agent;
    public float reachingRaidus;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerfoot.position);
        if (distance > reachingRaidus)
        {
            agent.isStopped = false;
            anim.SetBool("isWalking", true);
            agent.SetDestination(playerfoot.position);
            
        }
        else
        {
            agent.isStopped = true;
            anim.SetBool("isWalking", false);
        }
    }
}
