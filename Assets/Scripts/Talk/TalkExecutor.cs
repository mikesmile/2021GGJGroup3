using System;
using DG.Tweening;
using RemptyTool.ES_MessageSystem;
using UnityEngine;
using UnityEngine.UI;

public class TalkExecutor : MonoBehaviour
{
    [SerializeField]
    private Image leftImage;
    [SerializeField]
    private Image rightImage;
    [SerializeField]
    private Text text;

    [field : SerializeField]
    public MessageGroup MessageGroup { get; private set; }
    public ES_MessageSystem messageSystem { get; private set; }
    public string Message => this.messageSystem.text;

    void Start()
    {
        this.messageSystem = GetComponent<ES_MessageSystem>();
        this.leftImage.sprite = this.MessageGroup.leftSprite;
        this.rightImage.sprite = this.MessageGroup.rightSprite;
        for(int i = 0; i < 2; i++)
            for(int j = 0; j < 2; j++)
                this.messageSystem.AddSpecialCharToFuncMap(
                    (i == 0 ? "show" : "hide") + "-" + (j == 0 ? "left" : "right"),
                    this.spriteAction(i, j)
                );
        this.messageSystem.SetText(this.MessageGroup.Message);
    }

    private Action spriteAction(int show, int right)
    {
        var endColor = show == 0 ? Color.white : new Color(1, 1, 1, 0);
        var targetImage = right == 1 ? this.rightImage : this.leftImage;
        return () => targetImage.DOColor(endColor, 0.1f);
    }

    void Update()
    {
        // TODO: configure key
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.messageSystem.Next();
        }
        if(!this.messageSystem.IsCompleted)
        {
            this.text.text = this.messageSystem.text;
        }
    }
}