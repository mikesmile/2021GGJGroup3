using UnityEngine;

[CreateAssetMenu(fileName = "New Message Group", menuName = "Talk/Message Group")]
public class MessageGroup : ScriptableObject
{
    [field : SerializeField]
    public Sprite leftSprite { get; private set; }

    [field : SerializeField]
    public Sprite rightSprite { get; private set; }

    [SerializeField]
    private TextAsset messagesFile;
    public string Message => this.messagesFile.text;

}