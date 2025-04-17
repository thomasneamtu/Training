using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour, IInteractable, IPuzzlePiece
{
    [SerializeField] private bool IsButtonPressed = false;
    [SerializeField] private AudioSource buttonClick;
   
    public void StartInteraction()
    {
        Debug.Log("Button Pressed!");
        buttonClick.Play();
        IsButtonPressed = true;
    }

    public void StopInteraction()
    {
        throw new System.NotImplementedException();
    }
    
    public bool IsCorrect()
    {
        if (IsButtonPressed)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
