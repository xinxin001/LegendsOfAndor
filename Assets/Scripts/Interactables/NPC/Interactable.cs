using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //public UnityEngine.AI.NavMeshAgent playerAgent;

    public virtual void Interact(){
    	Debug.Log("Interacting with base class.");
    }
}
