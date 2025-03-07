using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealthPoint;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
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
        if (isDead) return;

        healthPoint -= damage;
        if (isDead)
        {
            Die();
        }    
    }

    private void Die()
    {
        anim.SetTrigger("Die");
    }
}
