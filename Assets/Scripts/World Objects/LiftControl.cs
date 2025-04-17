using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftControl : MonoBehaviour
{
    [SerializeField] float liftSpeed;
    [SerializeField] private Vector3 elevatedOffSet;
    private Vector3 initialPosition;
    public bool isActive;

    public void Start()
    {
        initialPosition = transform.position;
    }

    public void Update()
    {
        if (isActive)
        {
            LiftMoving();
        }
       
    }

    public void LiftMoving()
    {
        Vector3 targetPosition = initialPosition + elevatedOffSet;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * liftSpeed);
    }

    public void ActivateLift()
    {
       isActive = true;
    }
}
