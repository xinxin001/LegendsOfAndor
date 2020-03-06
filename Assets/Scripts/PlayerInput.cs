using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float m_h;
    public float H { get { return m_h; } }

    private float m_v;
    public float V { get { return m_v; }}




    bool m_inputEnabled = false;
    public bool InputEnabled
    {
        get { return m_inputEnabled; }

        //Here in the setter is where we'll modify the player's energy through the UI
        set { m_inputEnabled = value; }
    }

    public void GetKeyInput()
    {
        if(m_inputEnabled)
        {
            m_h = Input.GetAxisRaw("Horizontal");
            m_v = Input.GetAxisRaw("Vertical");
        }
    }


}
