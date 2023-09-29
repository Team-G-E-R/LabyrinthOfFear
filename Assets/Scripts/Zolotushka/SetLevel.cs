using System.Collections;
using Common.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetLevel : MonoBehaviour
{
    [SerializeField] private LevelConnection _levelConnection;
    [SerializeField] private string _targetSceneName;
    [SerializeField] private Transform _spawnPointPlayer;
    [SerializeField] private Transform _spawnPointCamera;
    
    FadeInOut fade;

    private void Start()
    {
        if (_levelConnection == LevelConnection.ActiveConnection)
        {
            GameObject.FindWithTag("Player").transform.position = _spawnPointPlayer.position;
            GameObject.FindWithTag("MainCamera").transform.position = _spawnPointCamera.position;
        }
    }

    public void OnCollisionEnter (Collision other)
    {
        var player = GameObject.FindWithTag("Player").transform;
        if (player != null)
        {
            LevelConnection.ActiveConnection = _levelConnection;
            fade = FindObjectOfType<FadeInOut>();
            StartCoroutine(LoadLevel());   
        }
    }

    IEnumerator LoadLevel()
    {
        GameObject.FindWithTag("Player").GetComponent<movement>().enabled = false;
        fade.FadeIn();
        yield return new WaitForSeconds(fade.duration + 1);
        SceneManager.LoadScene(_targetSceneName);
    }
}
