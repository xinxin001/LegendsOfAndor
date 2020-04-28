using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(gameManager.Narrator == GameManager.NarratorProgress.A)
        {
            GameObject A = GameObject.Find("A");
            gameObject.transform.position = A.transform.position;
        }
        else if (gameManager.Narrator == GameManager.NarratorProgress.B)
        {
            GameObject B = GameObject.Find("B");
            gameObject.transform.position = B.transform.position;
        }
    }
}
