using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandAbility : MonoBehaviour
{
    [SerializeField] private LayerMask compatibleWithCommands;
    [SerializeField] private CompanionController companion;

    [SerializeField] private GameObject waypointPrefab;
    void Awake()
    {
        if (companion == null)
        {
            companion = FindObjectOfType<CompanionController>();
        }
    }

    public void Command()
    {
        companion.GiveCommand(new MoveCommand(transform.position));
        Instantiate(waypointPrefab,transform.position, Quaternion.identity);   
    }
}
