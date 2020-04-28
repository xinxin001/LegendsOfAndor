using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Gold : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject region;
    public int amount;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(region);
            stream.SendNext(region);

        }
        else if (stream.IsReading)
        {
            region = (GameObject)stream.ReceiveNext();
            amount = (int)stream.ReceiveNext();

        }
    }

    public static Gold Create(GameObject createRegion, int amount, GameObject _gold)
    {
        Vector3 createRegionPosition = createRegion.transform.position;
        GameObject goldTransform = PhotonNetwork.Instantiate("Gold", createRegionPosition, Quaternion.identity);
        Gold gold = goldTransform.GetComponent<Gold>();
        gold.region = createRegion;
        gold.amount = amount;
        return gold;
    }
}
