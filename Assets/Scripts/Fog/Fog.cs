using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using Photon.Pun;

[RequireComponent(typeof(PolygonCollider2D))]


public class Fog : MonoBehaviourPunCallbacks, IPunObservable
{
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteR;
    public bool isUsed = false;
    public GameObject region;
    public string fogType;
    private Sprite image;
    private Sprite hidden;
    
    

    public Color32 oldColor;
    public Color32 hoverColor;
    public Color32 startColor;
    public Color32 emptyColor;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(spriteRenderer);
            stream.SendNext(spriteR);
            stream.SendNext(isUsed);
            stream.SendNext(fogType);
            stream.SendNext(image);
            stream.SendNext(hidden);

        }
        else if (stream.IsReading)
        {
            spriteRenderer = (SpriteRenderer)stream.ReceiveNext();
            spriteR = (SpriteRenderer)stream.ReceiveNext();
            isUsed = (bool)stream.ReceiveNext();
            fogType = (string)stream.ReceiveNext();
            image = (Sprite)stream.ReceiveNext();
            hidden = (Sprite)stream.ReceiveNext();
        }
    }

    void Awake()
    {
        
        //spriteR = GetComponent<SpriteRenderer>();
        //spriteR.color = startColor;
    }

    public static Fog Create(GameObject createRegion)
    {
        Vector3 createRegionPosition = createRegion.transform.position;
        Transform fogTransform = Instantiate(GameAssets.i.pfFog, createRegionPosition, Quaternion.identity);
        Fog fog = fogTransform.GetComponent<Fog>();
        fog.region = createRegion;
        return fog;
    }

    public void reveal()
    {
        Debug.Log("I am here");
        //spriteRenderer.sprite = image;
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("revealToken", RpcTarget.All);
    }

    [PunRPC]
    public void revealToken() {
        spriteRenderer.sprite = image;
        isUsed = true;
    }

    public void Update()
    {
        /*
        if (false)
        {
            spriteR.color = UtilsClass.GetColorFromString("000000");
        }
        else
        {
            spriteR.color = startColor;
        }*/
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = hidden; // set the sprite to sprite1
    }
    public void SetType(string type, Sprite s)
    {
        this.fogType = type;
        //spriteR.sprite = s;
        image = s;
        //spriteRenderer.sprite = s;
    }
    public string getFogType()
    {
        return fogType;
    }
}
