using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAbility : MonoBehaviour
{
    [SerializeField] private LayerMask interactionFilter;
    [SerializeField] private Transform interactionTip;
    [SerializeField] private GrabbingAbility grabbingAbility;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Interact()
    {
        Ray customRay = new Ray(interactionTip.position, interactionTip.forward);
        RaycastHit tempHit;

        if (!Physics.Raycast(customRay, out tempHit, 5f, interactionFilter))
        {

            grabbingAbility.DropDownObject();
            return;
        }    
            
        IInteractable interactFeature = tempHit.collider.GetComponent<IInteractable>();
        if (interactFeature != null)
        {
            interactFeature.StartInteraction();
        }
        else if(tempHit.rigidbody)
        {
            grabbingAbility.PickUpObject(tempHit.rigidbody);
        }

    }
}
