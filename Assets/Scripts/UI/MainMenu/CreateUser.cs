using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class CreateUser : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text placeholderText;

    [SerializeField]
    private InputField inputField;

    [SerializeField]
    private GameSettings gameSettings;

    public void OnClick_CreateUser() {
        if (inputField.text.Trim() == "")
        {
            Debug.Log("Invalid username: Empty");
            placeholderText.text = "Please enter a valid username";
            inputField.text = "";
        } else if (inputField.text.Length >= 20) {
            Debug.Log("Invalid username: Too long");
            placeholderText.text = "Your username must be at most 20 characters";
            inputField.text = "";
        }
        else {
            int randint = new System.Random().Next(0, 100);
            gameSettings.NickName = inputField.text + randint.ToString();
            placeholderText.text = "Enter a username";
            PhotonNetwork.LoadLevel("Rooms");
        }
    }
}
