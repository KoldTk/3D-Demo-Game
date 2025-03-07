using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionRadius;
    public float explosionForce;
    public int damage;

    private List<Health> oldVictims = new List<Health>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        BlowObject();
    }

    private void BlowObject()
    {
        oldVictims.Clear();
        Collider[] affectedObject = Physics.OverlapSphere(transform.position, explosionRadius);
        for (int i = 0; i < affectedObject.Length; i++)
        {
            DeliverDamage(affectedObject[i]);
            AddForceToObject(affectedObject[i]);

        }    
    }    
    private void DeliverDamage(Collider victim)
    {
        Health health = victim.GetComponentInParent<Health>();
        if (health != null && !oldVictims.Contains(health))
        {
            health.TakeDamage(damage);
            oldVictims.Add(health);
        }
    }
    private void AddForceToObject(Collider affectedObject)
    {
        Rigidbody rigidbody = affectedObject.attachedRigidbody;
        if (rigidbody)
        {
            rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
        }
    }
}
