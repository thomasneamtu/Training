using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PhysicalTrigger : MonoBehaviour, IInteractable
{
    public UnityEvent playerNearDoor;
    public bool playerInTrigger = false;

    public void OnTriggerEnter(Collider other)
    {
        playerInTrigger = true;
        StartInteraction();
    }

    public void OnTriggerExit(Collider other)
    {
        playerInTrigger = false;  
    }

    public void StartInteraction()
    {
        Debug.Log("Near The Door!");
        playerNearDoor.Invoke();   
    }

    public void StopInteraction()
    {

    }
}
