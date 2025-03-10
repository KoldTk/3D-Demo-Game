using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public Animator anim;
    public int damage;
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartAttack() => anim.SetBool("isAttacking", true);

    public void StopAttack() => anim.SetBool("isAttacking", false);

    public void OnAttack()
    {
        playerHealth.TakeDamage(damage);
    }
}
