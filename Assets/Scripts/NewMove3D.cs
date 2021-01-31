using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public enum SIDe{ Left, Mid, Right }

public class NewMove3D : MonoBehaviour
{
    public SIDe m_Side = SIDe.Mid;
    float NewXPos = 0f;
    public bool SwipeLeft;
    public bool SwipeRight;
    public bool SwipeFoward;
    public float XValue;
    public static bool factorR = false;
    public static bool factorL = false;
    public static bool factorF = false;
    private CharacterController m_char;
    public GameObject Target;
    public Transform trn;

    void Start()
    {
        transform.position = new Vector3(0,0,6);
        this.trn = GetComponent<Transform>();
        m_char = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        SwipeLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        SwipeRight = Input.GetKeyDown(KeyCode.RightArrow);
        SwipeFoward = Input.GetKeyDown(KeyCode.UpArrow);

        Vector3 Movedir = new Vector3(1,0,0);
        Vector3 mMovedir = new Vector3(-1,0,0);

        if (SwipeLeft)
        {
            factorL = true;
            factorR = false;
            factorF = false;
            if (m_Side == SIDe.Mid)
            {
                m_Side = SIDe.Left;
                m_char.Move(mMovedir * XValue);
            }
            else if (m_Side == SIDe.Right)
            {
                m_Side = SIDe.Mid;
                m_char.Move(mMovedir * XValue);
            }
        }
        else if (SwipeRight)
        {
            factorR = true;
            factorL = false;
            factorF = false;

            if (m_Side == SIDe.Mid)
            {
                m_Side = SIDe.Right;
                m_char.Move(Movedir * XValue);
            }
            else if (m_Side == SIDe.Left)
            {
                m_Side = SIDe.Mid;
                m_char.Move(Movedir * XValue);
            }
        }

        if (Target.transform.position.z - this.trn.position.z < 1)
        {
            Debug.Log(0);
            if (SwipeFoward)
            {
                Debug.Log(5);
                factorF = true;
                factorR = false;
                factorL = false;
            }
        }
    }
}

