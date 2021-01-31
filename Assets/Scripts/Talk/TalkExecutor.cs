using System;
using DG.Tweening;
using RemptyTool.ES_MessageSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[RequireComponent(typeof(ES_MessageSystem))]
public class TalkExecutor : MonoBehaviour
{
    [Header("Messages")]
    public UnityEvent OnMessageEnd;
    [field : SerializeField]
    public MessageGroup MessageGroup { get; private set; }

    [Header("UI objects")]
    [SerializeField]
    private Image background0;
    [SerializeField]
    private Image background1;
    [SerializeField]
    private Image leftImage;
    [SerializeField]
    private Image rightImage;
    [SerializeField]
    private Text text;
    [SerializeField]
    private Text headline;

    public ES_MessageSystem messageSystem { get; private set; }
    public string Message => this.messageSystem.text;
    private int activeBackgroundIndex;

    void Start()
    {
        this.messageSystem = GetComponent<ES_MessageSystem>();
        // setup background
        this.background0.color = Color.clear;
        this.background1.color = Color.clear;
        // setup character images
        this.leftImage.sprite = this.MessageGroup.leftSprite;
        this.leftImage.SetNativeSize();
        this.rightImage.sprite = this.MessageGroup.rightSprite;
        this.rightImage.SetNativeSize();
        // character sprite control
        for(int i = 0; i < 2; i++)
            for(int j = 0; j < 2; j++)
                this.messageSystem.AddSpecialCharToFuncMap(
                    (i == 0 ? "show" : "hide") + "-" + (j == 0 ? "left" : "right"),
                    this.spriteAction(j == 0 ? this.leftImage : this.rightImage, i == 0)
                );
        // register callback for background
        for(int i = 0; i < this.MessageGroup.Backgrounds.Count; i++)
            this.messageSystem.AddSpecialCharToFuncMap(
                $"bg {i}",
                this.backgroundAction(this.MessageGroup.Backgrounds[i])
            );
        // register headlines callback
        for(int i = 0; i < this.MessageGroup.Headlines.Count; i++)
        {
            var headline = this.MessageGroup.Headlines[i];
            this.messageSystem.AddSpecialCharToFuncMap(
                $"head {i}",
                () => this.headline.text = headline
            );
        }
        // end event
        this.messageSystem.AddSpecialCharToFuncMap("end", this.OnMessageEnd.Invoke);
        this.messageSystem.SetText(this.MessageGroup.Message);
    }

    private Action spriteAction(Image image, bool show)
    {
        var endColor = show ? Color.white : Color.clear;
        return () => image.DOColor(endColor, 0.1f);
    }

    private Action backgroundAction(Sprite background)
    {
        return () =>
        {
            var backgrounds = new [] { this.background0, this.background1 };
            var currentBackground = backgrounds[this.activeBackgroundIndex];
            var nextBackground = backgrounds[1 - this.activeBackgroundIndex];
            nextBackground.sprite = background;
            nextBackground.DOColor(Color.white, 0.3f);
            currentBackground.DOColor(Color.clear, 0.3f);
            this.activeBackgroundIndex = 1 - this.activeBackgroundIndex;
        };
    }

    public void NextMessage() => this.messageSystem.Next();

    void Update()
    {
        if(!this.messageSystem.IsCompleted)
        {
            this.text.text = this.messageSystem.text;
        }
        else
        {
            Debug.Log("finally");
        }
    }
}