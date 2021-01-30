using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody rig;
    public float thrust = 1.0f;
    void Start()
    {
        this.rig = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        if (Impulse.RightImpulse == true)
        {
            rig.AddForce(thrust, 0, 0, ForceMode.Impulse);
            Impulse.RightImpulse = false;
            
        }
        if (Impulse.LeftImpulse == true)
        {
            Debug.Log(33);
            rig.AddForce(-thrust, 0, 0, ForceMode.Impulse);
            Impulse.LeftImpulse = false;
        }
    } 
}
