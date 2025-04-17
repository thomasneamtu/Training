using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;

public class CompanionController : MonoBehaviour
{
   
    [SerializeField] private Queue<Command> commandQueue = new Queue<Command>();
    
    Command currentCommand;
    private NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
       if (currentCommand != null && !currentCommand.IsCommandComplete()) return;
       
       if (commandQueue.Count == 0)  return;

       currentCommand = commandQueue.Dequeue();
       currentCommand.Execute();
    }

    public void GiveCommand(Command newCommand)
    {
        newCommand.SetCompanionController(this);
        commandQueue.Enqueue(newCommand);
    }
    public void FinishCommand()
    {
        Debug.Log("About To Finish Command");
        commandQueue.Dequeue();
    }

    

    public NavMeshAgent GetNavMeshAgent()
    {
        //using method allows access to the private agent at the top
        return agent;
    }
}
