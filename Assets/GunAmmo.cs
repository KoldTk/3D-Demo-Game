using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunAmmo : MonoBehaviour
{
    public int magSize;
    public ShootingMechanic gun;
    public Animator anim;
    public AudioSource reloadSound;
    public UnityEvent loadedAmmoChanged;

    private int _loadedAmmo;
    public int LoadedAmmo
    {
        get => _loadedAmmo;
        set
        {
            _loadedAmmo = value;
            loadedAmmoChanged.Invoke();
            if (_loadedAmmo <= 0)
            {
                Reload();
            }
            else
            {
                UnlockShooting();
            }
        }
    }

    private void Reload()
    {
        anim.SetTrigger("Reload");
        LockShooting();
    }

    private void Start()
    {
        RefillAmmo();

    }

    public void SingleFireAmmoCount() => LoadedAmmo--;

    private void RefillAmmo()
    {
        LoadedAmmo = magSize;
    }

    private void UnlockShooting()
    {
        gun.enabled = true;
    }

    private void LockShooting()
    {
        gun.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            PlayerReloadSound();
            RefillAmmo();
        }    
    }

    public void PlayerReloadSound() => reloadSound.Play();
}
