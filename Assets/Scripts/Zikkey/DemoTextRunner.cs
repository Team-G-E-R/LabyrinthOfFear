using UnityEngine;

[RequireComponent(typeof(DynamicText))]
public class DemoTextRunner : MonoBehaviour
{
    [SerializeField] private TextInstance _testText;

    private void Start()
    {
        GetComponent<DynamicText>().ChangeText(_testText);    
    }
}
