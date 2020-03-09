// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Region : MonoBehaviour
// {
//     Vector2 m_coordinate;
//     public Vector2 Coordinate { get { return Utility.Vector2Round(m_coordinate); } }

//     List<Node> m_neighborNodes = new List<Node>();
//     public List<Node> NeighborNodes { get { return m_neighborNodes; } }

//     Board m_board;

//     public GameObject geometry;

//     public float scaleTime = 0.3f;

//     public iTween.EaseType easeType = iTween.EaseType.easeInExpo;

//     public bool autoRun;

//     public float delay = 1f;

//     // Start is called before the first frame update


//     private void Awake()
//     {
//         m_board = Object.FindObjectOfType<Board>();
//         m_coordinate = new Vector2(transform.position.x, transform.position.z);
//     }


//     void Start()
//     {
//         if (geometry != null) { geometry.transform.localScale = Vector3.zero; }

//         if (autoRun) { ShowGeometry(); }

//         if (m_board != null) { m_neighborNodes = FindNeighbors(m_board.AllNodes); }
//     }

//     public void ShowGeometry()
//     {
//         if(geometry != null)
//         {
//             iTween.ScaleTo(geometry, iTween.Hash(
//                 "time", scaleTime,
//                 "scale", Vector3.one,
//                 "easetype", easeType,
//                 "delay", delay
//                 ));
//         }
//     }

//     public List<Node> FindNeighbors(List<Node> nodes)
//     {
//         List<Node> nList = new List<Node>();

//         foreach(Vector2 dir in Board.directions)
//         {
//             Node foundNeighbor = nodes.Find(n => n.Coordinate == Coordinate + dir);

//             if( foundNeighbor !=null && !nList.Contains(foundNeighbor)){
//                 nList.Add(foundNeighbor);
//             }
//         }
//         return nList;
//     }

// }
