using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class GameObjectPool : UIBase<GameObjectPool>
{
    public List<Sprite> canHitData;
    [SerializeField]
    private GameObject m_prefab;
    [SerializeField]
    private int m_initailSize = 10;

    private List<GameObject> m_availableObjects = new List<GameObject>();

    protected override void Awake()
    {
        base.Awake();

        for (int i = 0; i < m_initailSize; i++)
        {
            GameObject go = Instantiate<GameObject>(m_prefab, this.transform);
            m_availableObjects.Add(go);
            go.SetActive(false);
        }
    }

    public GameObject GetPooledInstance(Transform parent, Sprite sprite, AnimatorController animator )
    {
        //Debug.LogError(parent.gameObject.name);

            int lastIndex = m_availableObjects.Count - 1;
            if (lastIndex >= 0)
            {
                GameObject go = m_availableObjects[lastIndex];

                //BoxCollider boxCollider = go.GetComponent<BoxCollider>();
                //if(boxCollider != null) Destroy(boxCollider);

                m_availableObjects.RemoveAt(lastIndex);
                if(sprite != null) go.GetComponent<SpriteRenderer>().sprite = sprite;
                if(animator != null ) go.GetComponent<Animator>().runtimeAnimatorController = animator;

                if (sprite == null)
                    go.tag = "CanHit";
                else
                    go.tag = "CanNotHit";

                go.SetActive(true);

                //go.AddComponent<BoxCollider>();
                //go.GetComponent<BoxCollider>().isTrigger = true;

                if (go.transform.parent != parent)
                {
                
                    go.transform.SetParent(parent);
                }
                return go;
            }
            else
            {
                GameObject go = Instantiate<GameObject>(m_prefab, Config.Self.transform);
                //go.SetActive(false);
                return go;
            }

    }

    public void BackToPool(GameObject go)
    {
        m_availableObjects.Add(go);
        go.SetActive(false);
    }
}