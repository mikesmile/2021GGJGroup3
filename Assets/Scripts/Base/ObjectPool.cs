using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : UIBase<ObjectPool>
{
    public List<Sprite> canHitData;
    public GameObject prefab;
    public int initailSize = 20;

    private Queue<GameObject> m_pool = new Queue<GameObject>();

    protected override void Awake()
    {
        base.Awake();

        for (int cnt = 0; cnt < initailSize; cnt++)
        {
            GameObject go = Instantiate(prefab,this.transform) as GameObject;
            m_pool.Enqueue(go);
            go.SetActive(false);
        }
    }

    public GameObject ReUse(Vector3 position, Quaternion rotation, Sprite sprite)
    {
        if (m_pool.Count > 0)
        {
            GameObject reuse = m_pool.Dequeue();
            reuse.GetComponent<SpriteRenderer>().sprite = sprite;

            if (canHitData.Contains(sprite))
                reuse.tag = "CanHit";
            else
                reuse.tag = "CanNotHit";

            reuse.transform.position = position;
            reuse.transform.rotation = rotation;
            reuse.SetActive(true);

            return reuse;
        }
        else
        {
            GameObject go = Instantiate(prefab) as GameObject;
            go.transform.position = position;
            go.transform.rotation = rotation;

            return go;
        }
    }


    public void Recovery(GameObject recovery)
    {
        m_pool.Enqueue(recovery);
        recovery.SetActive(false);
    }
}
