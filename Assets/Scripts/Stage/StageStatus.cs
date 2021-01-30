using UniRx;
using UnityEngine;

[CreateAssetMenu(menuName = "Stage/Status", fileName = "New Stage Status")]
public class StageStatus : ScriptableObject
{
    public IntReactiveProperty HP { get; private set; }
    public IntReactiveProperty Score { get; private set; }

    public void Reset()
    {
        this.Score = new IntReactiveProperty(0);
        this.HP = new IntReactiveProperty(3); // maybe this can be configured?
    }

    public void Hit()
    {
        this.HP.Value--;
        if(this.HP.Value == 0)
        {
            // TODO: reset stage
            Debug.Log("Fail...");
        }
    }

    public void AddScore(int delta)
    {
        // TODO: trigger fbx
        this.Score.Value += delta;
    }
}