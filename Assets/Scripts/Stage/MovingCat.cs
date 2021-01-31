using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovingCat : MonoBehaviour
{
    [SerializeField]
    private float targetY;
    [SerializeField]
    private float yDelta;
    [SerializeField]
    private float upInterval;
    [SerializeField]
    private float downInterval;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(0.3f, 2.8f));
        yield return this.jump();
    }

    private IEnumerator jump()
    {
        var originY = transform.position.y;
        yield return DOTween.Sequence()
            .Append(
                transform
                .DOMoveY(this.targetY + Random.Range(-this.yDelta, this.yDelta), this.upInterval)
                .SetEase(Ease.OutCubic)
            )
            .Append(
                transform
                .DOMoveY(originY, this.downInterval)
                .SetEase(Ease.InCubic)
            )
            .WaitForCompletion();
        yield return new WaitForSeconds(Random.Range(0.8f, 3f));
        yield return this.jump();
    }
}