using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
        if(Impulse.RightImpulse == true)
        {
            rig.AddForce(thrust, 0, 0, ForceMode.Impulse);
            Impulse.RightImpulse = false;

        }
        if(Impulse.LeftImpulse == true)
        {
            Debug.Log(33);
            rig.AddForce(-thrust, 0, 0, ForceMode.Impulse);
            Impulse.LeftImpulse = false;
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     Debug.Log("Trigger");
    //     // if(Impulse.RightImpulse)
    //     //     // this.rig.AddForce(thrust, 0, 0, ForceMode.Impulse);
    //     //     this.rig.velocity = Vector2.right * thrust;
    //     // else if(Impulse.LeftImpulse)
    //     //     // this.rig.AddForce(-thrust, 0, 0, ForceMode.Impulse);
    //     //          this.rig.velocity = Vector2.left * thrust;
    //     this.rig.isKinematic = false;
    //     // this.rig.DOMove(transform.position + Vector3.left * thrust, 0.3f);
    //     // this.rig.DORotate(Vector3.forward * 720, 0.5f);
    //     // transform.DOMoveX(transform.position.x - thrust, 0.3f);
    //     // transform.DORotate(Vector3.forward * 1080, 1f);
    //     // this.rig.MovePosition(transform.position + Vector3.left * thrust);
    //     this.rig.velocity = (Vector2.left + Vector2.up) * thrust;
    // }
}