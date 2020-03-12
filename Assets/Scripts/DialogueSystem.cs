using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
	
    public static DialogueSystem Instance {get; set;}
    public GameObject dialoguePanel;
    public GameObject CurrentHero;
    //public GameObject dialoguePanel = GameObject.Find("Dialogue");
    
    Button buySP;
    Button exitButton;
    Button buyWineskin;
    Button buyFalcon;
    Button buyShield;
    Button buyBow;
    Button buyHelm;
    Button buyTelescope;
   

    void Awake(){

    	//Get Buttons
    	buySP = dialoguePanel.transform.Find("BuyStrengthPoint").GetComponent<Button>();
    	buyWineskin = dialoguePanel.transform.Find("BuyWineskin").GetComponent<Button>();
    	buyFalcon = dialoguePanel.transform.Find("BuyFalcon").GetComponent<Button>();
    	buyShield = dialoguePanel.transform.Find("BuyShield").GetComponent<Button>();
    	buyBow = dialoguePanel.transform.Find("BuyBow").GetComponent<Button>();
    	buyHelm = dialoguePanel.transform.Find("BuyHelm").GetComponent<Button>();
    	buyTelescope = dialoguePanel.transform.Find("BuyTelescope").GetComponent<Button>();
    	exitButton = dialoguePanel.transform.Find("ExitButton").GetComponent<Button>();
  
    	
    	//Listeners
    	buySP.onClick.AddListener(buySPFunc);
    	buyWineskin.onClick.AddListener(buyWineskinFunc);
    	buyFalcon.onClick.AddListener(buyFalconFunc);
    	buyShield.onClick.AddListener(buyShieldFunc);
    	buyBow.onClick.AddListener(buyBowFunc);
    	buyHelm.onClick.AddListener(buyHelmFunc);
    	buyTelescope.onClick.AddListener(buyTelescopeFunc);
    	exitButton.onClick.AddListener(exitDialogue);
    	

    	dialoguePanel.SetActive(false);
    	
    	
    	if (Instance != null && Instance != this){
    		Destroy(gameObject);
    	}else{
    		Instance = this;
    	}
    }

    public void startDialogue(){
    	dialoguePanel.SetActive(true);
    }

    void buySPFunc(){
    	Debug.Log("Buy SP");
    	int currentSP = CurrentHero.getSP();
    	CurrentHero.setmaxSP(currentSP);
    }

    void buyWineskinFunc(){
    	Debug.Log("Buy WS");
    }

    void buyFalconFunc(){
    	Debug.Log("Buy Falcon");
    }

    void buyShieldFunc(){
    	Debug.Log("Buy Shield");
    }

    void buyBowFunc(){
    	Debug.Log("Buy Bow");
    }

    void buyHelmFunc(){
    	Debug.Log("Buy Helm");
    }

    void buyTelescopeFunc(){
    	Debug.Log("Buy Telescope");
    }

    void exitDialogue(){
    	dialoguePanel.SetActive(false);
    }
    

}
