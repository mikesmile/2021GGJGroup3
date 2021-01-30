using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleRun : MonoBehaviour
{
    private float obstacleSpeed;
    private float targetZ;
    private Vector3 groundPos;
    private bool stopRun = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopRun)
        {
            //transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
            transform.localPosition += ((Vector3.back.normalized) * Time.deltaTime * obstacleSpeed);
            if (transform.localPosition.z <= targetZ)
            {
                stopRun = true;
                GameObjectPool.Self.BackToPool(this.gameObject);
                //this.gameObject.SetActive(false);
                //Destroy(this.gameObject, 3);
            }

        }
    }

   

    public void Init( Vector3 groundPos, float targetZ, float obstacleSpeed )
    {
        this.obstacleSpeed = obstacleSpeed;
        this.groundPos = groundPos;
        this.targetZ = targetZ;
        stopRun = false;
        transform.localPosition += new Vector3(groundPos.x, groundPos.y, groundPos.z);
    }
}
