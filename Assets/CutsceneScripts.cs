using System.Collections;
using System.Collections.Generic;
using Common.Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CutsceneScripts : MonoBehaviour
{
    [SerializeField] private GameObject Active;
    [SerializeField] private GameObject ActiveText;
    [SerializeField] private string SceneToLoad;
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
        SceneManager.LoadScene(SceneToLoad);
    }
}
