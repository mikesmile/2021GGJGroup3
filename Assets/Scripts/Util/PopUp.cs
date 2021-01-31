using DG.Tweening;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float duration;
    [SerializeField]
    private bool autoDisable;

    // do the pop up
    public void Do()
    {
        this.target.SetActive(true);
        var trans = this.target.transform;
        trans.localScale = Vector3.zero;
        trans
            .DOScale(Vector3.one, this.duration)
            .SetEase(Ease.OutCubic)
            .OnComplete(() => this.target.SetActive(!this.autoDisable));
    }
}