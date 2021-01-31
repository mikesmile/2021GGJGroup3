using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public enum SIDE { Left, Mid, Right }

public class Move3D : MonoBehaviour
{
    public float hitRadio;
    public Vector3 rootPosition;
    public SIDE m_Side = SIDE.Mid;
    float NewXPos = 0f;
    public bool SwipeLeft;
    public bool SwipeRight;
    public bool SwipeForward;
    public float XValue;
    private CharacterController m_char;

    private Vector3 noHitPosition;
    private UseBtn currentUse = UseBtn.None;
    private float _timer;
    private bool countdown;
    public int hitPower;
    private Animator mainAnimator;
    enum UseBtn
    {
        None,
        Left,
        Right,
        Forward,
    }

    void Start()
    {
        transform.localPosition = rootPosition;
        noHitPosition = transform.localPosition;
        m_char = GetComponent<CharacterController>();
        mainAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SwipeLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        SwipeRight = Input.GetKeyDown(KeyCode.RightArrow);
        SwipeForward = Input.GetKeyDown(KeyCode.UpArrow);
        Vector3 Movedir = new Vector3(1, 0, 0);
        Vector3 mMovedir = new Vector3(-1, 0, 0);

        if (SwipeLeft)
        {
            currentUse = UseBtn.Left;
            mainAnimator.SetTrigger("Left");
            if (m_Side == SIDE.Mid)
            {
                noHitPosition = transform.localPosition;//等待受擊位置更新
                m_Side = SIDE.Left;

                m_char.Move(mMovedir * XValue);
                countdown = true;
                _timer = Time.time;
            }
            else if(m_Side == SIDE.Right)
            {
                noHitPosition = transform.localPosition;
                m_Side = SIDE.Mid;

                m_char.Move(mMovedir * XValue);
                countdown = true;
                _timer = Time.time;
            }
        }
        if(SwipeRight)
        {
            currentUse = UseBtn.Right;
            mainAnimator.SetTrigger("Right");
            if (m_Side == SIDE.Mid)
            {
                noHitPosition = transform.localPosition;
                m_Side = SIDE.Right;

                m_char.Move(Movedir * XValue);
                countdown = true;
                _timer = Time.time;
            }
            else if(m_Side == SIDE.Left)
            {
                noHitPosition = transform.localPosition;
                m_Side = SIDE.Mid;

                m_char.Move(Movedir * XValue);
                countdown = true;
                _timer = Time.time;
            }
        }

        if (SwipeForward)
        {
            currentUse = UseBtn.Forward;
            _timer = Time.time;
            countdown = true;
            _timer = Time.time;
        }


        if (countdown) //給他一秒時間重返狀態
        {
            if (Time.time > _timer + 0.5f)
            {
                if(currentUse != UseBtn.None) currentUse = UseBtn.None;

                countdown = false;
                _timer = Time.time;
            }
        }

    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CanHit" && currentUse != UseBtn.None)
        {
            //Debug.LogError(currentUse);

            other.GetComponent<obstacleRun>().stopRun = true;
            other.GetComponent<obstacleRun>().objectPoolHitBack = true;
            other.GetComponent<obstacleRun>()._timer = Time.time;//reset timer

            //Debug.LogError(noHitPosition);
            //Debug.LogError("Enemy:"+other.transform.localPosition.x + " main:"+noHitPosition.x);
            var rb = other.GetComponent<Rigidbody>();
            // if(Impulse.RightImpulse)
            //     // this.rig.AddForce(thrust, 0, 0, ForceMode.Impulse);
            //     this.rig.velocity = Vector2.right * thrust;
            // else if(Impulse.LeftImpulse)
            //     // this.rig.AddForce(-thrust, 0, 0, ForceMode.Impulse);
            //          this.rig.velocity = Vector2.left * thrust;
            rb.isKinematic = false;

            if (other.transform.localPosition.x < noHitPosition.x - hitRadio && currentUse == UseBtn.Left) //往左撞
            {
                //Vector3 dir1 = GetRandomVector3(new Vector3(0, 0.5f, 5));
                //Vector3 dir2 = GetRandomVector3(new Vector3(-1, 0.5f, 5));
                //Vector3 dir3 = GetRandomVector3(new Vector3(-1, 0, 0));
                //Debug.LogError((dir1 + dir2 + dir3).normalized * 12);
                //rb.velocity = (dir1 + dir2 + dir3).normalized * 12;
                rb.velocity = (Vector2.left + Vector2.up) * hitPower;
            }
            else if (other.transform.localPosition.x > noHitPosition.x + hitRadio && currentUse == UseBtn.Right)//往右撞
            {
                rb.velocity = (Vector2.right + Vector2.up) * hitPower;
            }
            else if (currentUse == UseBtn.Forward)
            {
                rb.velocity = (Vector3.forward + Vector3.up) * hitPower;
            }

        }

        currentUse = UseBtn.None;
        noHitPosition = transform.localPosition;//無真正受傷撞擊時更新位置
    }
  



    public Vector3 GetRandomVector3( Vector3 origin )
    {
        int r = UnityEngine.Random.Range(0, 10);
        return origin * r;
    }
}