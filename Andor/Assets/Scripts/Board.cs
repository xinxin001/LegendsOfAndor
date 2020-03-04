using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    //I'd maybe switch it to 4x4 floor tiles
    public static float spacing = 2f;

    //If you wanna make diagonals a direction too then just add em in here
    public static readonly Vector2[] directions =
    {
        new Vector2(spacing, 0f),
        new Vector2(-spacing, 0f),
        new Vector2(0f, spacing),
        new Vector2(0f, -spacing)
    };

    List<Node> m_allNodes = new List<Node>();
    public List<Node> AllNodes { get { return m_allNodes;  } }

    void Awake()
    {
        GetNodeList();    
    }

    public void GetNodeList()
    {
        Node[] nList = GameObject.FindObjectsOfType<Node>();
        m_allNodes = new List<Node>(nList);
    }
}
