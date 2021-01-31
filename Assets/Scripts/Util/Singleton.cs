using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if(!_instance)
                _instance = FindObjectOfType<T>();
            if(!_instance)
            {
                var go = new GameObject(typeof(T).ToString());
                _instance = go.AddComponent<T>();
            }
            return _instance;
        }
    }

    protected virtual bool shouldDestroy() => false;

    private void Awake()
    {
        if(Instance != this)
        {
            Debug.LogWarning($"Got duplicated singleton objects ({gameObject.name})");
            Destroy(this);
            return;
        }
        if(!this.shouldDestroy())
            DontDestroyOnLoad(gameObject);
    }
}