using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected CompanionController companionController;
    public void SetCompanionController(CompanionController tempCompanion)
    {
        companionController = tempCompanion;
    }
    public abstract void Execute();
    public abstract void Cancel();
    public abstract bool IsCommandComplete();
   
}
