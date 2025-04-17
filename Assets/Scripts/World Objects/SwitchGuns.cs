using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchGuns : MonoBehaviour, IInteractable
{
    public UnityEvent OnGunGrabbed;
    public bool IsGunGrabbed = false;
    public void StartInteraction()
    {
        Debug.Log("HandGun Equipped");
        OnGunGrabbed.Invoke();
        IsGunGrabbed = true;
        gameObject.SetActive(false);
        
    }

    public void StopInteraction()
    {
        throw new System.NotImplementedException();
    }

   
}
