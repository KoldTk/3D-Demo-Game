using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AmmoTextBinder : MonoBehaviour
{
    public TMP_Text loadedAmmoText;
    public GunAmmo gunAmmo;
    // Start is called before the first frame update
    void Start()
    {
        gunAmmo.loadedAmmoChanged.AddListener(UpdateGunAmmo);
        UpdateGunAmmo();
    }

    private void UpdateGunAmmo()
    {
        loadedAmmoText.text = gunAmmo.LoadedAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
