using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public enum SIDE{ Left, Mid, Right }

public class Move3D : MonoBehaviour
{
    public Vector3 rootPosition;
    public SIDE m_Side = SIDE.Mid;
    float NewXPos = 0f;
    public bool SwipeLeft;
    public bool SwipeRight;
    public float XValue;
    private CharacterController m_char;

    void Start()
    {
        transform.position = rootPosition;
        m_char = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        SwipeLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        SwipeRight = Input.GetKeyDown(KeyCode.RightArrow);
        Vector3 Movedir = new Vector3(1,0,0);
        Vector3 mMovedir = new Vector3(-1,0,0);
        if (SwipeLeft)
        {
            if (m_Side == SIDE.Mid)
            {
                m_Side = SIDE.Left;
                m_char.Move(mMovedir * XValue);
            }
            else if (m_Side == SIDE.Right)
            {
                m_Side = SIDE.Mid;
                m_char.Move(mMovedir * XValue);
            }
        }
        if (SwipeRight)
        {
            if (m_Side == SIDE.Mid)
            {
                m_Side = SIDE.Right;
                m_char.Move(Movedir * XValue);
            }
            else if (m_Side == SIDE.Left)
            {
                m_Side = SIDE.Mid;
                m_char.Move(Movedir * XValue);
            }
        }
    }
}

