using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHandler : MonoBehaviour
{
    public Hero hero;
    float moveSpeed = 10;

    void Awake()
    {
        hero = GetComponent<Hero>();
    }
    void OnMouseUp()
    {
        Debug.Log("hero should move");
        float horizontalInput = Input.GetAxis("Mouse X");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxis("Mouse Y");
        //Get the value of the Vertical input axis.

        transform.Translate(new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime);
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
    }
}