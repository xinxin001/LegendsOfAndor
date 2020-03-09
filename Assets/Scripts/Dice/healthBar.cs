using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{

    public Image Bar;
    public float Fill;


    // Start is called before the first frame update
    void Start()
    {
        Fill = 1f;
    }



    void Update()
    {
        Bar.fillAmount = Fill;
    }
}
