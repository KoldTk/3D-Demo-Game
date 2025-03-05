using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoNumber : MonoBehaviour
{
    public GunAmmo ammoNum;
    public TextMeshProUGUI ammoText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ammo before setting text: " + ammoNum.LoadedAmmo);
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Bullet: " + ammoNum.LoadedAmmo.ToString();
    }
}
