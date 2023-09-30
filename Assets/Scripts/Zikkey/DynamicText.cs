using System.Collections;
using UnityEngine;

public class DynamicText : MonoBehaviour
{
    [SerializeField] private KeyCode _next = KeyCode.E;
    [SerializeField] private TMPro.TMP_Text _output;

    private TextInstance _currentText;
    private int _currentChar = 0;

    private void Update()
    {
        if (Input.GetKeyDown(_next) == false)
            return;

        StopAllCoroutines();

        if (_output.text.Length != _currentText.Data.Length)
        {
            _output.text = _currentText.Data;
            return;
        }

        if (_currentText.Next != null)
            ChangeText(_currentText.Next);
        else
            ClearState();
    }

    public void ChangeText(TextInstance text)
    {
        StopAllCoroutines();

        ClearState();
        _currentText = text;

        StartCoroutine(RunText());
    }

    private IEnumerator RunText()
    {
        while (_currentChar != _currentText.Data.Length)
        {
            _output.text += _currentText.Data[_currentChar];
            yield return new WaitForSeconds(_currentText.ChangeSpeed);
            _currentChar += 1;
        }
    }

    private void ClearState()
    {
        _output.text = string.Empty;
        _currentChar = 0;
    }
}
