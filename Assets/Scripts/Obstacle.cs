using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Rigidbody rig;
    public Transform tra;
    public float thrust;
    void Start()
    {
        this.rig = GetComponent<Rigidbody>();
        rig.AddForce(0, 0, -3 ,ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (Move3D.factorR == true)
            {
                rig.AddForce(Vector3.right * thrust, ForceMode.Impulse);    
                Move3D.factorR = false;     
                Move3D.factorF = false;
            }
            else if (Move3D.factorL == true)
            {
                rig.AddForce(Vector3.left * thrust, ForceMode.Impulse);
                Move3D.factorL = false;
                Move3D.factorF = false;
            }
        }
    }
    void OnTriggerStay(Collider other) 
    {
        if (Move3D.factorF == true)
        {
            Debug.Log(3);
            rig.AddForce(0, 0, thrust, ForceMode.Impulse);
            Move3D.factorL = false;
            Move3D.factorR = false;
            Move3D.factorF = false;
        }
    }
}
