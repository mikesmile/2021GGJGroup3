using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Message Group", menuName = "Talk/Message Group")]
public class MessageGroup : ScriptableObject
{
    [field : SerializeField]
    public Sprite leftSprite { get; private set; }

    [field : SerializeField]
    public Sprite rightSprite { get; private set; }

    [SerializeField]
    private List<Sprite> backgrounds;
    public IReadOnlyList<Sprite> Backgrounds => this.backgrounds.AsReadOnly();

    [SerializeField]
    private List<string> headlines;
    public IReadOnlyList<string> Headlines => this.headlines.AsReadOnly();

    [SerializeField]
    private TextAsset messagesFile;
    public string Message => this.messagesFile.text;

}