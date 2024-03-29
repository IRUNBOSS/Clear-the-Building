using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private int maxAmmoCount = 5;
     private int ammoCount = 0;
    public int GetAmmo { get { return ammoCount; } 
        set { ammoCount = value; 
            if (ammoCount > maxAmmoCount) ammoCount = maxAmmoCount; } } 

    [SerializeField] private float fireRate = 0.5f;
    private float _currentFireRate = 0f;
    // Start is called before the first frame update
    void Start()
    {
        ammoCount = maxAmmoCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentFireRate > 0f)
        {
            _currentFireRate -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0)&& ammoCount >0)
        {
            if(_currentFireRate <= 0)
            {

                Fire();

            }
        }
    }

    private void Fire()
    {
        float difference = 180 - transform.eulerAngles.y;
        float targetRotation = 90;

        if(difference >= 90)
        {
            targetRotation = 90;
        }
        else if(difference < 90)
        {
            targetRotation = -90f;
        }

        ammoCount--;
        _currentFireRate = fireRate;
        GameObject bulletClone = Instantiate(ammo, fireTransform.position, Quaternion.Euler(0f, 0f, targetRotation));
        bulletClone.GetComponent<Bullet>().owner = gameObject;
    }
}

