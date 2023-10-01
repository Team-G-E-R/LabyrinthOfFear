using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Slider _soundVolume;
    [SerializeField] private AudioClip _startMenuSound;
    
    private LoadLevel _loadLevel;
    private AudioSource _audioSource;

    public void Construct(GameFactory gameFactory,
        IAudioService audioService)
    {
        _audioSource = audioService.AudioSource;
        _loadLevel = new LoadLevel(gameFactory);

        _audioSource.clip = _startMenuSound;
        _audioSource.Play();
        _soundVolume.onValueChanged.AddListener((v) => _audioSource.volume = v);
    }

    public void StartGame() => 
        _loadLevel.EnterLevel("House_outside");

    public void ExitGame() => 
        Application.Quit();
}
