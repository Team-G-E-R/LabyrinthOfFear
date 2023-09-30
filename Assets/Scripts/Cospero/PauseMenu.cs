using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isMenuActive=false;
    [SerializeField] KeyCode KeyToActivateMenu;
    [SerializeField] int mainMenuSceneIndex;

    private void Start ()
    {
        pauseMenu.SetActive(false);
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyToActivateMenu))
        {
            MenuActive();
        }
    }

    private void MenuActive()
    {
        
        isMenuActive=!isMenuActive;
        
        if (isMenuActive)
            {
                pauseMenu.SetActive(true);
                Time.timeScale=0f;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale=1f;
                
            }

        
    }

    public void continueButton()
    {
        MenuActive();
    }
    public void mainMenuButton()
    {
        Debug.Log("SceneChange");
        /* SceneManager.LoadScene(mainMenuSceneIndex); */
    }
    
}
