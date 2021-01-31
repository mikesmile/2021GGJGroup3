using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Animations;

public class Ground : MonoBehaviour
{
    public float speed;
    public float obstacleSpeed;
    private Renderer rend;

    public List<Sprite> obstacle;
    public AnimatorController animator;
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
            int r = UnityEngine.Random.Range(0, 2);
            //Debug.LogError("時間：" + Time.time + " 計數：" + _timer);
            if (Time.time > _timer + spawnTime)
            {
                if (r == 0) //Sprite 
                {
                    GetObstacleFromPool(r, obstacle[r]);
                }
                else if (r == 1) //Animator
                {
                    GetObstacleFromPool(r, null);
                }
                // GetObstacleFromPool(obstacle[r]);



                _timer = Time.time;
            }
        }
    }

    public Transform GetObstacleFromPool(int r, Sprite spawn)
    {

        int x = UnityEngine.Random.Range(-15, 15);
        if (r == 0)
        {
            GameObject obstacleCopy = GameObjectPool.Self.GetPooledInstance(Config.Self.transform, spawn, null);
            obstacleCopy.GetComponent<Animator>().runtimeAnimatorController = null;
            obstacleCopy.transform.localScale = new Vector3(1, 1, 1);
            //GameObject obstacleCopy = ObjectPool.Self.ReUse(new Vector3(x, 4, 11), Quaternion.identity, spawn);
            obstacleCopy.transform.localPosition = new Vector3(x, 4.31f, 11);
            //var obstacleCopy = Instantiate<GameObject>(spawn, new Vector3(x, 4, 11), Quaternion.identity );
            obstacleCopy.GetComponent<obstacleRun>().Init(transform.localPosition, -26, obstacleSpeed);

            return obstacleCopy.transform;
        }
        else if (r == 1)
        {
            GameObject obstacleCopy = GameObjectPool.Self.GetPooledInstance(Config.Self.transform, null, animator);
            obstacleCopy.GetComponent<SpriteRenderer>().sprite = null;
            obstacleCopy.transform.localScale = new Vector3(3, 3, 1);
            //GameObject obstacleCopy = ObjectPool.Self.ReUse(new Vector3(x, 4, 11), Quaternion.identity, spawn);
            obstacleCopy.transform.localPosition = new Vector3(x, 4.31f, 11);
            //var obstacleCopy = Instantiate<GameObject>(spawn, new Vector3(x, 4, 11), Quaternion.identity );
            obstacleCopy.GetComponent<obstacleRun>().Init(transform.localPosition, -26, obstacleSpeed);

            return obstacleCopy.transform;
        }

        return null;
    }
}