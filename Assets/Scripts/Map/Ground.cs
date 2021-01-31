using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ground : MonoBehaviour
{
    public float speed;
    public float obstacleSpeed;
    private Renderer rend;

    public List<Sprite> obstacle;
    public float spawnTime = 0.2f;
    private float _timer;

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
            //Debug.LogError("時間：" + Time.time + " 計數：" + _timer);
            if (Time.time > _timer + spawnTime)
            {
                GetObstacleFromPool(obstacle[r]);


                _timer = Time.time;
            }
        }
    }

    public Transform GetObstacleFromPool(Sprite spawn )
    {
        int x = UnityEngine.Random.Range(-15, 15);

        GameObject obstacleCopy = GameObjectPool.Self.GetPooledInstance(Config.Self.transform, spawn);
        //GameObject obstacleCopy = ObjectPool.Self.ReUse(new Vector3(x, 4, 11), Quaternion.identity, spawn);
        obstacleCopy.transform.localPosition = new Vector3(x, 4, 11);
        //var obstacleCopy = Instantiate<GameObject>(spawn, new Vector3(x, 4, 11), Quaternion.identity );
        obstacleCopy.GetComponent<obstacleRun>().Init(transform.localPosition, -26, obstacleSpeed);

        return obstacleCopy.transform;
    }
}