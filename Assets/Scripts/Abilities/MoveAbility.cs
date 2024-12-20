using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAbility : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] float movementSpeed;

    [Header("References")]
    [SerializeField] private CharacterController controller;
    // Start is called before the first frame update
    

    public void Move(Vector3 moveDirection)
    {

        Vector3 forwardMovement = moveDirection.z * transform.forward;
        Vector3 sidewaysMovement = moveDirection.x * transform.right;

        Vector3 movementVector = (forwardMovement + sidewaysMovement);

        controller.Move((movementVector) * Time.deltaTime * movementSpeed);
    }
    
}
