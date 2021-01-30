using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageUI : MonoBehaviour
{
    [field : SerializeField]
    public Text text { get; private set; }

    [field : SerializeField]
    public TalkExecutor executor { get; private set; }

    // Update is called once per frame
    void Update()
    {
        if(!this.executor.messageSystem.IsCompleted)
        {
            this.text.text = this.executor.Message;
        }
    }
}