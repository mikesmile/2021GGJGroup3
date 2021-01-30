using UnityEngine;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField]
    private StageStatus status;

    [SerializeField]
    private Button hitButton;

    [SerializeField]
    private Button gainButton;

    void Start()
    {
        this.status.Reset();
        this.hitButton.onClick.AddListener(() => this.status.Hit());
        this.gainButton.onClick.AddListener(() => this.status.AddScore(100));
    }
}