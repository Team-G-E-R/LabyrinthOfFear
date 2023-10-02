using System.Collections;
using System.Collections.Generic;
using Common.Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CutsceneScripts : MonoBehaviour
{
    [SerializeField] private GameObject Active;
    [SerializeField] private GameObject ActiveText;
    [SerializeField] private string SceneToLoad;
    [SerializeField] private PlayableDirector _director;
    public void StopAnim()
    {
        Active.SetActive(false);
    }

    public void RetrieveMovement()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
        player.enabled = true;
    }

    public void Activate()
    {
        ActiveText.SetActive(true);
    }

    public void LoadingScene()
    {
        var audioServiceToDelete = FindObjectOfType<AudioService>();
        Destroy(audioServiceToDelete.gameObject);
        SceneManager.LoadScene(SceneToLoad);
    }

    public void DirectorOn()
    {
        _director.Play();
    }
}
