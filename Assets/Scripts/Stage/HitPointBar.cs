using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class HitPointBar : MonoBehaviour
{
    private List<Heart> hearts;
    [SerializeField]
    private StageStatus status;

    void Start()
    {
        this.hearts = GetComponentsInChildren<Heart>().ToList();
        this.status.HP
            .Skip(1)
            .Subscribe(hp => this.Hit())
            .AddTo(this);
    }

    public bool Hit()
    {
        if(this.hearts.Count == 0)
            return false;
        var heart = this.hearts.Last();
        this.hearts.RemoveAt(this.hearts.Count - 1);
        heart.Break();
        return true;
    }
}