using System.Collections;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class OpeningStoryControl : MonoBehaviour
{
    [Header("Assets")]
    [SerializeField]
    private Image backgroundImage;
    [SerializeField]
    private GameObject executor;
    [SerializeField]
    private Sprite[] backgrounds;
    [Header("Transition")]
    [SerializeField]
    private float transitionTime;
    [SerializeField]
    private float interval;
    [Header("Neko Kami")]
    [SerializeField]
    private float nekoKamiTransitionTime;
    [SerializeField]
    private float nekoKamiFinalPositionY;
    [SerializeField]
    private float nekoKamiDownPositionY;

    private IEnumerator waitForTransition()
    {
        var lastTime = Time.time;
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || (Time.time - lastTime) > this.interval);
    }

    IEnumerator Start()
    {
        this.backgroundImage.color = Color.clear;
        this.backgroundImage.sprite = this.backgrounds[0];
        yield return this.backgroundImage
            .DOColor(Color.white, this.transitionTime)
            .WaitForCompletion();
        yield return this.waitForTransition();
        var count = this.backgrounds.Length - 2;
        foreach(var background in this.backgrounds.Skip(1).Take(count))
        {
            yield return this.backgroundImage
                .DOCrossfadeImage(background, this.transitionTime)
                .WaitForCompletion();
            yield return this.waitForTransition();
        }
        this.backgroundImage.color = Color.clear;
        this.backgroundImage.sprite = this.backgrounds[this.backgrounds.Length - 1];
        this.backgroundImage.SetNativeSize();
        this.backgroundImage.DOColor(Color.white, this.interval);
        this.backgroundImage.transform.Translate(Vector3.down * this.nekoKamiDownPositionY);
        yield return this.backgroundImage.transform
            .DOMoveY(this.nekoKamiFinalPositionY, this.nekoKamiTransitionTime)
            .WaitForCompletion();
        this.executor.SetActive(true);
    }
}