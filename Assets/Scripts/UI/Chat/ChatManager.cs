using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviourPunCallbacks
{
    int MAXMESSAGECOUNT = 50;

    // Serialize fields
    public GameObject chatPanel, textObject;
    public InputField chatBox;

    [SerializeField]
    public Text placeholder;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    public void clearMessages() {
        messageList.Clear();
    }

    void Update()
    {
        if (chatBox.text.Trim() != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(PhotonNetwork.LocalPlayer.NickName + ": " + chatBox.text);
                chatBox.text = "";
                Canvas.ForceUpdateCanvases();
                GameObject.Find("ChatLog").GetComponent<ScrollRect>().verticalNormalizedPosition = 0.01f;
                Canvas.ForceUpdateCanvases();
            }
        }
        else if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return)) {
            chatBox.ActivateInputField();
        }
    }

    // Add new message object to message list
    public void SendMessageToChat(string text) {

        // Check for message count
        if (messageList.Count >= MAXMESSAGECOUNT) {
            Destroy(messageList[0].textObject.gameObject);
            messageList.RemoveAt(0);
        }

        // Check for message length
        if (text.Length > 100) {
            chatBox.text = "";
            placeholder.text = "Message too long!";
            return;
        }

        // Call RPC method
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("sendMessageRPC", RpcTarget.All, text);

        placeholder.text = "Press 'Enter' to write and share messages...";
    }

    [PunRPC]
    public void sendMessageRPC(string text) {
        // Initalize new message obj
        Message newMessage = new Message();
        newMessage.text = text;
        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<Text>();
        newMessage.textObject.text = text;

        messageList.Add(newMessage);
    }

}

[System.Serializable]
public class Message {

    public string text;
    public Text textObject;

}