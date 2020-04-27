using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    public Transform pfFarmerLostPopup;

    public Transform pfFarmer;

    public Transform pfGold;

    public Transform pfWarrior;
    public Transform pfWarriorDisplay;

    public Transform pfWizard;
    public Transform pfWizardDisplay;

    public Transform pfDwarf;
    public Transform pfDwarfDisplay;

    public Transform pfArcher;
    public Transform pfArcherDisplay;

    public Transform pfGors;

    public Transform pfSkral;

    public Transform pfWardrak;

    public Transform pfPrinceThorald;

    public Transform pfMerchant;
    public Transform pfWitch;

    public Transform pfMerchantDisplayWarrior;
    public Transform pfWitchDisplayWarrior;

    public Transform pfMerchantDisplayDwarf;
    public Transform pfWitchDisplayDwarf;

    public Transform pfMerchantDisplayWizard;
    public Transform pfWitchDisplayWizard;

    public Transform pfMerchantDisplayArcher;
    public Transform pfWitchDisplayArcher;

    public Transform pfFog;
}
