using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerTurret : MonoBehaviour
{
    [SerializeField] private LayerMask damageFilter;
    [SerializeField] private Transform weaponTip;
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private LineRenderer lazerRenderer;
    [SerializeField] private float beamRange;
    [SerializeField] private AudioSource lazerSound;
    private float checkArea = 2f;
    

    private void FixedUpdate()
    {
        Vector3 endBeam = weaponTip.position + (weaponTip.forward * beamRange);
        RaycastHit hit;

        if (Physics.SphereCast(weaponTip.position, checkArea, weaponTip.forward, out hit, beamRange, damageFilter))
        {
            if (hit.rigidbody.CompareTag("Player"))
            {
                Debug.Log("Found:" + hit.rigidbody.name);
                Debug.Log("Entering Attack State!");
                lazerSound.Play();
                TurretAttack();
            }
        }
    }


    public void TurretAttack()
    {   
        
         Vector3 endBeam = weaponTip.position + (weaponTip.forward * beamRange);
         RaycastHit hit;

         lazerRenderer.enabled = true;
         lazerRenderer.SetPosition(0, weaponTip.position);
         lazerRenderer.SetPosition(1, endBeam);

         if (Physics.Raycast(weaponTip.position, weaponTip.forward, out hit, beamRange))
         {
             endBeam = hit.point;
             lazerRenderer.SetPosition(0, weaponTip.position);
             lazerRenderer.SetPosition(1, endBeam);
             Debug.Log("Hit:" + hit.collider.name);


             if (hit.rigidbody.CompareTag("Player"))
             {
                 healthSystem.DecreaseHealth(3);
                 Debug.Log("Hit Player!");
             }

         }

    }

}
