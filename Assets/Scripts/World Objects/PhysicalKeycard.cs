using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
public class PhysicalKeycard : MonoBehaviour, IInteractable, IPuzzlePiece
{
    [SerializeField] private GameObject keyCard;
    [SerializeField] private bool IsKeyCardGot = false;
    [SerializeField] private AudioSource keyCardClick;

    public void StartInteraction()
    {
        Debug.Log("Keycard Acquired!");
        IsKeyCardGot = true;
        keyCardClick.Play();
        gameObject.SetActive(false);
    }

    public void StopInteraction()
    {
        throw new NotImplementedException();
    }

    public bool IsCorrect()
    {
       if (IsKeyCardGot)
       {
            return true;
       }
       else
       {
            return false;
       }
    }

   
}
