using UnityEngine;

[CreateAssetMenu(fileName = "Text", menuName = "Game/Text")]
public class TextInstance : ScriptableObject
{
    [Multiline] public string Data;
    public float ChangeSpeed = 0.5f;
    public TextInstance Next;
}
