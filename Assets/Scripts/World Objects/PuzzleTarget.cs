using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTarget : MonoBehaviour, IPuzzlePiece
{
    [SerializeField] private GameObject puzzleTarget;
    [SerializeField] private bool puzzleTargetHit = false;
    [SerializeField] private AudioSource targetClick;

    private void OnCollisionEnter(Collision collision)
    {
        targetClick.Play();
        puzzleTargetHit = true;
        puzzleTarget.SetActive(false);
    }

    public bool IsCorrect()
    {
        if (puzzleTargetHit)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
