using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isMenuActive = false;
    [SerializeField] KeyCode KeyToActivateMenu;
    [SerializeField] int mainMenuSceneIndex;
    [SerializeField] private Slider _soundVolume;
    
    private AudioSource _audioSource;
    
    private void Start ()
    {
        pauseMenu.SetActive(false);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyToActivateMenu))
        {
            var audioService = FindObjectOfType<AudioService>();
            MenuActive(audioService);
        }
    }

    private void MenuActive(IAudioService audioService)
    {
        isMenuActive=!isMenuActive;

        if (isMenuActive)
        {
            _audioSource = audioService.AudioSource;
            
            _soundVolume.onValueChanged.AddListener((v) => _audioSource.volume = v);
            
            
            
            Cursor.visible = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            Cursor.visible = false;
        }
    }

    public void continueButton()
    {
        var audioService = FindObjectOfType<AudioService>();
        MenuActive(audioService);
    }
    
    public void mainMenuButton()
    {
        var audioServiceToDelete = FindObjectOfType<AudioService>();
        Destroy(audioServiceToDelete.gameObject);

        SceneManager.LoadScene(mainMenuSceneIndex);
        Time.timeScale = 1f;
    }
}
