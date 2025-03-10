using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealthPoint;
    public Animator anim;
    public UnityEvent onDie;
    ZombieMovement zombieMovement;
    // Start is called before the first frame update
    void Start()
    {
        zombieMovement = GetComponent<ZombieMovement>();
        healthPoint = maxHealthPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int healthPoint;
    private bool isDead => healthPoint <= 0;
    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }
        else
        {
            healthPoint -= damage;
        }

        if (isDead)
        {
            GetComponent<NavMeshAgent>().enabled = false;
            zombieMovement.enabled = false;

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            foreach (Rigidbody rbChild in GetComponentsInChildren<Rigidbody>())
            {
                rbChild.isKinematic = false;
            }
            Die();
        }
        
    }

    private void Die()
    {
        anim.SetTrigger("Die");
        onDie.Invoke();
    }
}
