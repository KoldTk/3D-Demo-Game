using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GunRaycaster : MonoBehaviour
{
    public HitEffectManager hitEffectManager;
    public Camera aimingCamera;
    public LayerMask layerMask;
    public int damage;

    public void PerformRaycasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);

        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            HitSurface hitSurface = hitInfo.collider.GetComponentInParent<HitSurface>();
            if (hitSurface != null)
            {
                ApplyHitEffect(hitSurface.surfaceType, hitInfo.point, effectRotation);
            }
            DeliverDamage(hitInfo);
        }
    }

    private void ApplyHitEffect(HitSurfaceType surfaceType, Vector3 point, Quaternion effectRotation)
    {
        foreach (var mapping in hitEffectManager.effectMap)
        {
            if (mapping.surface == surfaceType)
            {
                Instantiate(mapping.effectPrefab, point, effectRotation);
                break;
            }
        }

    }

    private void DeliverDamage(RaycastHit hitInfo)
    {
        Health health = hitInfo.collider.GetComponentInParent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
