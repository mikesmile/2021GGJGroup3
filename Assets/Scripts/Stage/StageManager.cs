using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [SerializeField]
    private StageStatus status;

    void Start()
    {
        this.status.Reset();
    }
}