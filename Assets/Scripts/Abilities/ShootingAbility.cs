using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAbility : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Rigidbody projectilePrefab;
    [SerializeField] private float shootingForce;

    ObjectPooling objectPoolingCache;

    private void Awake()
    {
        objectPoolingCache = FindObjectOfType<ObjectPooling>(); 
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        

        Rigidbody clonedRigidbody = objectPoolingCache.RetrieveAvailableBullet().GetRigidbody();
        
        if (clonedRigidbody == null) return;

        clonedRigidbody.position = weaponTip.position;
        clonedRigidbody.rotation = weaponTip.rotation;


        //Rigidbody clonedRigidbody = Instantiate(projectilePrefab, weaponTip.position, weaponTip.rotation);
        clonedRigidbody.AddForce(weaponTip.forward * shootingForce);
    }
}
