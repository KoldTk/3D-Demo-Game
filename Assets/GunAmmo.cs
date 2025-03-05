using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAmmo : MonoBehaviour
{
    public int magSize;
    public ShootingMechanic gun;
    public Animator anim;
    public AudioSource reloadSound;

    private int _loadedAmmo;
    public int LoadedAmmo
    {
        get => _loadedAmmo;
        set
        {
            _loadedAmmo = value;
            if (_loadedAmmo <= 0)
            {
                Reload();
                PlayerReloadSound();
                RefillAmmo();
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
        Debug.Log(_loadedAmmo);
        Debug.Log(LoadedAmmo);
        Debug.Log(magSize);
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
