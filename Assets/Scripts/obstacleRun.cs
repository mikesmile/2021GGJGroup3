using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleRun : MonoBehaviour
{
    private float obstacleSpeed;
    private float targetZ;
    private Vector3 groundPos;
    [HideInInspector]
    public bool stopRun = false;
    [HideInInspector]
    public bool objectPoolHitBack = false;
    [HideInInspector]
    public float _timer;
    // Start is called before the first frame update

    public GameObject animation;
    void Start()
    {
        
    }


    public void Init(Vector3 groundPos, float targetZ, float obstacleSpeed)
    {
        this.obstacleSpeed = obstacleSpeed;
        this.groundPos = groundPos;
        this.targetZ = targetZ;
        this.GetComponent<Rigidbody>().isKinematic = true;
        stopRun = false;
        objectPoolHitBack = false;
        transform.localPosition += new Vector3(groundPos.x, groundPos.y, groundPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogError("時間：" + Time.time + " 計數：" + _timer);
        if (objectPoolHitBack)
        {
            if (Time.time > _timer + 3.0f)
            {
                GameObjectPool.Self.BackToPool(this.gameObject);
                //ObjectPool.Self.Recovery(this.gameObject);
                objectPoolHitBack = false;
                _timer = Time.time;
            }

            //if (Mathf.Abs(Time.time - timeCount) >= 3.0f)
            //{

            //    GameObjectPool.Self.BackToPool(this.gameObject);
            //    timeCount = Time.time;
            //}
        }

        if (!stopRun)
        {
            transform.localPosition += ((Vector3.back.normalized) * Time.deltaTime * obstacleSpeed);
            if (transform.localPosition.z <= targetZ)
            {
                stopRun = true;
                GameObjectPool.Self.BackToPool(this.gameObject);
                //ObjectPool.Self.Recovery(this.gameObject);
                //this.gameObject.SetActive(false);
                //Destroy(this.gameObject, 3);
            }
            //if (this.transform.GetChild(0).gameObject.activeSelf)
            //{

            //    this.transform.GetChild(0).localPosition += ((Vector3.back.normalized) * Time.deltaTime * obstacleSpeed);
            //    if (this.transform.GetChild(0).localPosition.z <= targetZ)
            //    {
            //        stopRun = true;
            //        GameObjectPool.Self.BackToPool(this.gameObject);
            //        //ObjectPool.Self.Recovery(this.gameObject);
            //        //this.gameObject.SetActive(false);
            //        //Destroy(this.gameObject, 3);
            //    }
            //}
            //else
            //{
            //    //transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
            //    transform.localPosition += ((Vector3.back.normalized) * Time.deltaTime * obstacleSpeed);
            //    if (transform.localPosition.z <= targetZ)
            //    {
            //        stopRun = true;
            //        GameObjectPool.Self.BackToPool(this.gameObject);
            //        //ObjectPool.Self.Recovery(this.gameObject);
            //        //this.gameObject.SetActive(false);
            //        //Destroy(this.gameObject, 3);
            //    }
            //}
        }

        
    }


    //void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {

    //        if (Input.GetKeyDown(KeyCode.UpArrow))
    //        {
    //            Debug.LogError("123");

    //            GetComponent<Rigidbody>().velocity = (Vector3.forward + Vector3.up) * 12;
    //        }
    //    }
    //}

}
