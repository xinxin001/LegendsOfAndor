using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitFight : MonoBehaviour
{
    private Color startcolor;

    private void OnMouseUp()
    {
        SceneManager.LoadScene(2);
    }


    void OnMouseEnter()
    {
        startcolor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.red;
    }
    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startcolor;
    }

}
