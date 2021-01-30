using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float speed;
    public float obstacleSpeed;
    private Renderer rend;

    public List<Sprite> obstacle;
    private float timeCount = 0.0f;

    void Start()
    {
        this.rend = GetComponent<Renderer>();

       
    }

    void Update()
    {
        rend.material.SetTextureOffset("_MainTex", Vector2.down * (Time.time * this.speed));


        if (obstacle.Count != 0)
        {
            int r = UnityEngine.Random.Range(0, obstacle.Count);

            if (Mathf.Abs(Time.time - timeCount) >= 0.2f)
            {
                InitObstacle(obstacle[r]);
                //ShootBullet( new Vector3( 1, 0, 0 ), 2 );
                //ShootBullet( new Vector3( 1, 1, 0 ), 2 );
                //ShootBullet( new Vector3( 0, 1, 0 ), 2 );
                //ShootBullet( new Vector3( -1, 1, 0 ), 2 );
                //ShootBullet( new Vector3( -1, 0, 0 ), 2 );
                //ShootBullet( new Vector3( -1, -1, 0 ), 2 );
                //ShootBullet( new Vector3( 0, -1, 0 ), 2 );
                //ShootBullet( new Vector3( 1, -1, 0 ), 2 );

                timeCount = Time.time;
            }
        }
    }

    public Transform InitObstacle(Sprite spawn )
    {
        int x = UnityEngine.Random.Range(-15, 15);

        GameObject obstacleCopy =  GameObjectPool.Self.GetPooledInstance(this.transform.parent, spawn);
        obstacleCopy.transform.localPosition = new Vector3(x, 4, 11);
        //var obstacleCopy = Instantiate<GameObject>(spawn, new Vector3(x, 4, 11), Quaternion.identity );
        obstacleCopy.GetComponent<obstacleRun>().Init(transform.localPosition, -26, obstacleSpeed);

        return obstacleCopy.transform;
    }
}