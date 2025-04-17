using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] private PhysicalKeycard keyCard;
    [SerializeField] private PhysicalTrigger doorTrigger;
    [SerializeField] private Vector3 openOffset;
    [SerializeField] private float doorSpeed;
    private Vector3 closedPosition;

    public bool isPlayerNear = false;
    public bool isKeycardGot = false;

    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        closedPosition = transform.position;

        if (doorTrigger != null) doorTrigger.playerNearDoor.AddListener(playerInTrigger);

        //if (keyCard != null) keyCard.gotKeycard.AddListener(KeyCardGot);

    }

    // Update is called once per frame
    void Update()
    {
        if (isKeycardGot && isPlayerNear)
        {
            OpenDoor();
        }

        if (isOpen)
        {
            Vector3 targetPosition = closedPosition + openOffset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * doorSpeed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, closedPosition, Time.deltaTime * doorSpeed);
        }
    }

    public void playerInTrigger()
    {
        isPlayerNear = true;
    }
    public void KeyCardGot()
    {
        isKeycardGot = true;
    }

    public void OpenDoor()
    {
        Debug.Log("The Door Is Open!");
        isOpen = true;
    }

    public void CloseDoor()
    {
        isOpen = false;
    }
}
