using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealthPoint;
    public UnityEvent playerDie;
    public int healthPoint;
    private bool isDead => healthPoint <= 0;
    // Start is called before the first frame update
    void Start()
    {
        healthPoint = maxHealthPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        if (isDead) return;
        healthPoint -= damage;
        if(isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        playerDie.Invoke();
    }
}
