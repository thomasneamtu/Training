using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private MoveAbility moveAbility;
    [SerializeField] private LookAblility lookAblility;
    [SerializeField] private ShootingAbility shootingAbility;
    [SerializeField] private JumpAbility jumpAbility;
    [SerializeField] private InteractAbility interactAbility;

    private Vector2 lookDirection;


    [SerializeField] private CharacterController controller;

    [SerializeField] float mouseSensitivity;

    [SerializeField] private LayerMask groundLayer;

    [Header("Shooting Settings")]
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Rigidbody projectilePrefab;
    [SerializeField] private float shootingForce;

    // Start is called before the first frame update
    void Start()
    {
        //Controlling Mouse Cursor
        Cursor.visible = false; //Hiding Cursor
        Cursor.lockState = CursorLockMode.Locked; //Locking Cursor to the center of the screen
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAbility)
        {
            Vector3 moveDir = new Vector3();
            moveDir.x = Input.GetAxis("Horizontal");
            moveDir.z = Input.GetAxis("Vertical");
            moveAbility.Move(moveDir);
        }

        if (lookAblility)
        {
            lookDirection.x += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
            lookDirection.y += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
            float angleOnY = lookDirection.y;
            lookDirection.y = Mathf.Clamp(angleOnY, -80, 80);

            lookAblility.Look(lookDirection);
        }

        if (shootingAbility != null && Input.GetMouseButtonDown(0))
        {
            shootingAbility.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpAbility.Jump();
        }
        
        if (interactAbility && Input.GetKeyDown(KeyCode.F))
        {
            interactAbility.Interact();
        }
    }

    //testing sphere location
    private void OnDrawGizmos()
    {
        //drawing a sphere right at the feet of the player
        Gizmos.DrawSphere(transform.position, 0.1f);
    }

}
