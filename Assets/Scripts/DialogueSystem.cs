using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
	
    public static DialogueSystem Instance {get; set;}
    public GameObject dialoguePanel;
    //public GameObject dialoguePanel = GameObject.Find("Dialogue");
    
    Button buySP;
   

    void Awake(){
    	//dialoguePanel = GameObject.Find("Canvas/Dialogue");
    	buySP = dialoguePanel.transform.Find("BuyStrengthPoint").GetComponent<Button>();
    	//buySP = dialoguePanel.transform.Find("BuyStrengthPoint").GetComponent<Button>();
    	//buySP = dialoguePanel.transform.GetChild(0).gameObject;
    	buySP.onClick.AddListener(buySPFunc);
    	dialoguePanel.SetActive(false);
    	
    	/*
    	if (Instance != null && Instance != this){
    		Destroy(GameObject);
    	}else{
    		Instance = this;
    	}*/
    }

    void startDialogue(){
    	dialoguePanel.SetActive(true);
    }

    void buySPFunc(){
    	Debug.Log("Buy SP");
    }

}
