using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class DynamicText : MonoBehaviour
{
    [SerializeField] private KeyCode _next = KeyCode.E;
    [SerializeField] private TMPro.TMP_Text _output;
    [SerializeField] private PlayableDirector director;

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
        {
            ClearState();
            if (director != null)
            {
                director.Play();
            }
            else
            {
                Debug.Log("Where is director?");
            }
        }
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
        _output.text = null;
        _currentChar = 0;
    }
}
