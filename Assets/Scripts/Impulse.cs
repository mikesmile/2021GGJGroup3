using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    public Transform m_Trans;
    public static bool RightImpulse;
    public static bool LeftImpulse;
    void Start()
    {
        m_Trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        GameObject hitObject = hit.collider.gameObject;
        if (hitObject.CompareTag("Player"))
        {
            Debug.Log(12);
            if (m_Trans.position.x > 0)
            {
                RightImpulse = true;
            }
            else
            {
                RightImpulse = false;
            }

            if (m_Trans.position.x < 0)
            {
                LeftImpulse = true;
            }
            else
            {
                LeftImpulse = false;
            }
        }
    }

}
