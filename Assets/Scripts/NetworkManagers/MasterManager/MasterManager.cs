using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;


[CreateAssetMenu(menuName = "Singletons/MasterManager")]

public class MasterManager : SingletonScriptableObject<MasterManager>
{
    [SerializeField]
    private GameSettings _gameSettings;

    public static GameSettings GameSettings
    {
        get
        {
            return Instance._gameSettings;
        }
    }

    [SerializeField]
    private List<NetworkedPrefab> _networkedPrefabs = new List<NetworkedPrefab>();


    public static GameObject NetworkInstantiate(GameObject obj, Vector3 position, Quaternion rotation)
    {
        Debug.Log("Instantiating...");
        foreach (NetworkedPrefab networkedPrefab in Instance._networkedPrefabs)
        {
            if (networkedPrefab.Prefab == obj)
            {
                Debug.Log("Game object found");
                if (networkedPrefab.Path != string.Empty)
                {
                    GameObject result = PhotonNetwork.Instantiate(networkedPrefab.Path, position, rotation);
                    Debug.Log("Game object instantiated");
                    return result;
                }
                else
                {
                    Debug.LogError("Path is empty for gameobject name " + networkedPrefab.Prefab);
                    return null;
                }
            }
        }

        return null;
    }

    //    // RUN ONCE
//    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
//    private static void PopulateNetworkedPrefabs()
//    {
//#if UNITY_EDITOR
        //Instance._networkedPrefabs.Clear();

        //GameObject[] results = Resources.LoadAll<GameObject>("");
        //for (int i = 0; i < results.Length; i++)
        //{
        //    if (results[i].GetComponent<PhotonView>() != null)
        //    {
        //        string path = AssetDatabase.GetAssetPath(results[i]);
        //        Instance._networkedPrefabs.Add(new NetworkedPrefab(results[i], path));
        //    }
        //}
        ////DEBUGGING PURPOSES
        //for (int i = 0; i < Instance._networkedPrefabs.Count; i++)
        //{
        //    UnityEngine.Debug.Log(Instance._networkedPrefabs[i].Prefab.name + ", " + Instance._networkedPrefabs[i].Path);
        //}

//#endif
//    }
}