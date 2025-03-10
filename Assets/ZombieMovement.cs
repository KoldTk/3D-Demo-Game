using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZombieMovement : MonoBehaviour
{
    public Transform playerfoot;
    public Animator anim;
    public NavMeshAgent agent;
    public float reachingRaidus;
    public UnityEvent onDestinationReached;
    public UnityEvent onStartMoving;

    private bool _isMovingValue;
    public bool IsMoving
    {
        get => _isMovingValue;
        private set
        {
            if (_isMovingValue == value) return;
            _isMovingValue = value;
            OnIsMovingValueChanged();
        }
    }

    private void OnIsMovingValueChanged()
    {
        agent.isStopped = !_isMovingValue;
        anim.SetBool("isWalking", _isMovingValue);
        if (_isMovingValue)
        {
            onStartMoving.Invoke();
        }
        else
        {
            onDestinationReached.Invoke();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerfoot.position);
        IsMoving = distance > reachingRaidus;
        if (IsMoving)
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
