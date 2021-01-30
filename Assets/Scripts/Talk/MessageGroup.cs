using UnityEngine;

[CreateAssetMenu(fileName = "New Message Group", menuName = "Talk/Message Group")]
public class MessageGroup : ScriptableObject
{
    [field : SerializeField]
    public Sprite leftSprite { get; private set; }

    [field : SerializeField]
    public Sprite rightSprite { get; private set; }

    // TODO: encapsulate this field to be modified outside
    [TextArea]
    public string Message;
    [field : SerializeField]
    public TextAsset[] messages { get; private set; }

}