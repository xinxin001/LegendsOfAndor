using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Hero))]

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
    Hero myHero;
   

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
  		myHero = CurrentHero.GetComponent<Hero>();
    	
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
    	int currentSP = myHero.getmaxSP;
    	myHero.setmaxSP(currentSP+1);
    	int currentGold = myHero.getGold;
    	myHero.setGold(currentGold - 2);
    }

    void buyWineskinFunc(){
    	Debug.Log("Buy WS");
    	int currentGold = myHero.getGold;
    	myHero.setGold(currentGold - 2);
    	int currentWineskin = myHero.getWineskin;
    	myHero.setWineskin(currentWineskin+1);
    }

    void buyFalconFunc(){
    	Debug.Log("Buy Falcon");
    	int currentGold = myHero.getGold;
    	myHero.setGold(currentGold - 2);
    	int current = myHero.getFalcon;
    	myHero.setFalcon(current+1);
    }

    void buyShieldFunc(){
    	Debug.Log("Buy Shield");
    	int currentGold = myHero.getGold;
    	myHero.setGold(currentGold - 2);
    	int current = myHero.getShield;
    	myHero.setShield(current+1);
    }

    void buyBowFunc(){
    	Debug.Log("Buy Bow");
    	int currentGold = myHero.getGold;
    	myHero.setGold(currentGold - 2);
    	int current = myHero.getBow;
    	myHero.setBow(current+1);
    }

    void buyHelmFunc(){
    	Debug.Log("Buy Helm");
    	int currentGold = myHero.getGold;
    	myHero.setGold(currentGold - 2);
    	int current = myHero.getHelm;
    	myHero.setHelm(current+1);
    }

    void buyTelescopeFunc(){
    	Debug.Log("Buy Telescope");
    	int currentGold = myHero.getGold;
    	myHero.setGold(currentGold - 2);
    	int current = myHero.getTelescope;
    	myHero.setTelescope(current+1);
    }

    void exitDialogue(){
    	dialoguePanel.SetActive(false);
    }
    

}
