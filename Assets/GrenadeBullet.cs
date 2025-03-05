using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionRadius;
    public float explosionForce;
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
        Collider[] affectedObject = Physics.OverlapSphere(transform.position, explosionRadius);
        for (int i = 0; i < affectedObject.Length; i++)
        {
            Rigidbody rigidbody = affectedObject[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
            }    
        }    

    }    

}
