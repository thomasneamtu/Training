using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAbility : MonoBehaviour
{
    [SerializeField] private LayerMask interactionFilter;
    [SerializeField] private Transform interactionTip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Interact()
    {
        Ray customRay = new Ray(interactionTip.position, interactionTip.forward);
        RaycastHit tempHit;

        if (Physics.Raycast(customRay, out tempHit, 5f, interactionFilter))
        {
            Debug.Log("I Hit" + tempHit.collider.name);
        }
        else
        {
            Debug.Log("Not Hitting Anything");
        }

        Debug.DrawRay(transform.position, transform.forward * 5f, Color.green);
    }


}
