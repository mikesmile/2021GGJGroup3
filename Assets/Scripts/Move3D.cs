using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public enum SIDE { Left, Mid, Right }

public class Move3D : MonoBehaviour
{
    public SIDE m_Side = SIDE.Mid;
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
        Vector3 Movedir = new Vector3(1, 0, 0);
        Vector3 mMovedir = new Vector3(-1, 0, 0);
        if(SwipeLeft)
        {
            if(m_Side == SIDE.Mid)
            {
                m_Side = SIDe.Left;
                m_char.Move(mMovedir * XValue);
            }
            else if(m_Side == SIDE.Right)
            {
                m_Side = SIDe.Mid;
                m_char.Move(mMovedir * XValue);
            }
        }
        if(SwipeRight)
        {
            if(m_Side == SIDE.Mid)
            {
                m_Side = SIDe.Right;
                m_char.Move(Movedir * XValue);
            }
            else if(m_Side == SIDE.Left)
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        var rb = other.GetComponent<Rigidbody>();
        // if(Impulse.RightImpulse)
        //     // this.rig.AddForce(thrust, 0, 0, ForceMode.Impulse);
        //     this.rig.velocity = Vector2.right * thrust;
        // else if(Impulse.LeftImpulse)
        //     // this.rig.AddForce(-thrust, 0, 0, ForceMode.Impulse);
        //          this.rig.velocity = Vector2.left * thrust;
        rb.isKinematic = false;
        // this.rig.DOMove(transform.position + Vector3.left * thrust, 0.3f);
        // this.rig.DORotate(Vector3.forward * 720, 0.5f);
        // transform.DOMoveX(transform.position.x - thrust, 0.3f);
        // transform.DORotate(Vector3.forward * 1080, 1f);
        // this.rig.MovePosition(transform.position + Vector3.left * thrust);
        rb.velocity = (Vector2.left + Vector2.up) * 12;
    }
}