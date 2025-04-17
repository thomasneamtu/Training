using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance;

    [SerializeField] private MoveAbility moveAbility;
    [SerializeField] private LookAblility lookAblility;
    [SerializeField] private ShootingAbility shootingAbility;
    [SerializeField] private JumpAbility jumpAbility;
    [SerializeField] private InteractAbility interactAbility;
    [SerializeField] private CommandAbility commandAbility;
    private Vector2 lookDirection;

    [SerializeField] private CharacterController controller;
    [SerializeField] private SwitchGuns switchGuns;
    [SerializeField] private GameController gameController;
    private SceneLoader sceneManager; 

    [SerializeField] private AudioSource tgunShot;
    [SerializeField] private AudioSource gunShot;

    [SerializeField] float mouseSensitivity;

    [SerializeField] private LayerMask groundLayer;

    [Header("Shooting Settings")]
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Rigidbody projectilePrefab;
    [SerializeField] private float shootingForce;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<HealthSystem>().onDead += () =>
        {
            this.enabled = false;
        };

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

        if (shootingAbility != null && !switchGuns.IsGunGrabbed && Input.GetMouseButtonDown(0))
        {
            tgunShot.Play();
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
        
        if(commandAbility && Input.GetMouseButtonDown(1))
        {
            commandAbility.Command();
        }

        if (switchGuns.IsGunGrabbed && !gameController.IsGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Game Over!");
                gunShot.Play();
                gameController.GameOver();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sceneManager.QuitGame();
        }


    }

    //testing sphere location
    private void OnDrawGizmos()
    {
        //drawing a sphere right at the feet of the player
        Gizmos.DrawSphere(transform.position, 0.1f);
    }

}
