using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public GameObject door;

    public float timer;

    private void OnTriggerEnter(Collider other)
    {
        //change door color (visual effects)
    }
     
    
    private void OnTriggerStay(Collider other)
    {
       

        //By Input Logic

        if (Input.GetKeyDown(KeyCode.F))
        {
            door.SetActive(false); 
        }
        
        
        
        
        /* By Timer Logic
        timer += Time.deltaTime;

        if (timer >= 2)
        {
            door.SetActive(false);
        }
        */
    }

    private void OnTriggerExit(Collider other)
    {
        timer = 0;
        door.SetActive(true);
    }
}
