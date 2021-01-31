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
    public GameObject HittiingSound;
    public GameObject Life_Losing_Sound;
    [SerializeField]
    private StageStatus status;
    public bool Hit;


    //private GameObject fx;
    // HACK: prevent duplicated trigger
    private bool hasBeenHit;

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
                Hit = true;
                noHitPosition = transform.localPosition;//等待受擊位置更新
                m_Side = SIDE.Left;

                m_char.Move(mMovedir * XValue);
                countdown = true;
                _timer = Time.time;
            }
            else if(m_Side == SIDE.Right)
            {
                Hit = true;
                noHitPosition = transform.localPosition;
                m_Side = SIDE.Mid;

                m_char.Move(mMovedir * XValue);
                countdown = true;
                _timer = Time.time;
            }
        }
        if(SwipeRight)
        {
            Hit = true;
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
                Hit = true;
                noHitPosition = transform.localPosition;
                m_Side = SIDE.Mid;

                m_char.Move(Movedir * XValue);
                countdown = true;
                _timer = Time.time;
            }
        }

        if (SwipeForward)
        {
            Hit = true;
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

        if(currentUse != UseBtn.Forward )
        {
            if(currentUse != UseBtn.Right && currentUse != UseBtn.Left)
            {
                Hit = false;
            }
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        // if (Hit == false)
        // {
        //    Instantiate(Life_Losing_Sound);
        // }

        // if (other.tag == "CanHit" && currentUse != UseBtn.None)
        if (other.tag == "CanHit")
        {

            this.hasBeenHit = !this.hasBeenHit;
            if(this.hasBeenHit)
                return;
            if(currentUse != UseBtn.None)
            {
                other.GetComponent<obstacleRun>().stopRun = true;
                other.GetComponent<obstacleRun>().objectPoolHitBack = true;
                other.GetComponent<obstacleRun>()._timer = Time.time;//reset timer

                var rb = other.GetComponent<Rigidbody>();
                rb.isKinematic = false;

                if (other.transform.localPosition.x < noHitPosition.x - hitRadio && currentUse == UseBtn.Left) //往左撞
                {
                    rb.velocity = (Vector2.left + Vector2.up) * hitPower;
                    //fx = Instantiate(Resources.Load<GameObject>("FX/hit_vfx"), this.transform);
                    //fx.transform.localPosition = new Vector3(0.4f, 2.2f, 0);

                    status.AddScore(3);
                    Instantiate(HittiingSound);
                }
                else if (other.transform.localPosition.x > noHitPosition.x + hitRadio && currentUse == UseBtn.Right)//往右撞
                {
                    rb.velocity = (Vector2.right + Vector2.up) * hitPower;
                    //fx = Instantiate(Resources.Load<GameObject>("FX/hit_vfx"), this.transform);
                    //fx.transform.localPosition = new Vector3(0.4f, 2.2f, 0);

                    status.AddScore(3);
                    Instantiate(HittiingSound);
                }
                else if (currentUse == UseBtn.Forward)//往前撞
                {
                    rb.velocity = (Vector3.forward + Vector3.up) * hitPower;
                    //fx = Instantiate(Resources.Load<GameObject>("FX/hit_vfx"), this.transform);
                    //fx.transform.localPosition = new Vector3(0, 2.2f, 0);

                    status.AddScore(3);
                    Instantiate(HittiingSound);
                }
                
            } else {
                Instantiate(Life_Losing_Sound);
                status.Hit();

                if(status.HP.Value == 0)
                {
                    TransitionPanel.Self.LoadScene("Menu");
                }
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

