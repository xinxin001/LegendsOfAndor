using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantNPC : NPC
{
    

    public override void Interact(){
    	DialogueSystem.Instance.startDialogue();
    	Debug.Log("Interacting with Merchant");
    }

    
}
