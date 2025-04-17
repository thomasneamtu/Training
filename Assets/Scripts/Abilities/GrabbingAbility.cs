using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingAbility : MonoBehaviour
{
    [SerializeField] private Transform holdingHand;
    [SerializeField] private float syncStrength;
    private Rigidbody objectinHold;

    public void PickUpObject(Rigidbody toGrab)
    {
        if (objectinHold != null)
        {
            DropDownObject();
            return;
        }


        objectinHold = toGrab;
        toGrab.useGravity = false;
        toGrab.transform.position = holdingHand.position;
        toGrab.drag = 10;


        //DOESNT APPLY PHYSICS TO OBJECT
        //toGrab.transform.SetParent(holdingHand);
        //toGrab.isKinematic = true;
    }
    
    public void DropDownObject()
    {
        if (objectinHold)
        {
            objectinHold.useGravity = true;
            objectinHold = null;


            //SAME AS ABOVE
            //objectinHold.isKinematic = false;
            //objectinHold.transform.SetParent(null);
        }
    }

    private void Update()
    {
        if (objectinHold != null && Vector3.Distance(holdingHand.position, objectinHold.transform.position) > 0.1f)
        {
            MoveObject();
        }
    }


    private void MoveObject()
    {
        Vector3 targetDirection = holdingHand.position - objectinHold.transform.position;
        objectinHold.AddForce(targetDirection* syncStrength);


    }


}
