using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAbility : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float gravityAcceleration = -9.81f;
    private float currentGravity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!IsOnGround())
        {
            currentGravity += gravityAcceleration * Time.deltaTime;
        }
        else if (currentGravity < 0)
        {
            currentGravity = 0;
        }

        Vector3 gravityVector = new Vector3();
        gravityVector.y = currentGravity;
        controller.Move(gravityVector * Time.deltaTime);
    }

    public bool IsOnGround()
    {
        return Physics.CheckSphere(transform.position, 0.1f, groundLayer);
    }

    public void AddForce(Vector3 force)
    {
        currentGravity = force.y;
    }
}