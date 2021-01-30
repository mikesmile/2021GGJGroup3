using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private StageStatus status;

    private void Start()
    {
        this.status.Score.SubscribeToText(GetComponent<Text>());
    }
}