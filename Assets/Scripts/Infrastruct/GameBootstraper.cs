using UnityEngine;

public class GameBootstraper : MonoBehaviour
{
    private GameFactory _gameFactory;
    private AllServices _allServices;

    private void Awake()
    {
        _gameFactory = new GameFactory();
        _allServices = new AllServices();

        AudioService audioService = InstantiateAudioService();
        RegisterAudioService(audioService);
        
        StartMenu startMenu = _gameFactory
            .CreateStartMenu()
            .GetComponent<StartMenu>();
        startMenu.Construct(_gameFactory, audioService);
    }

    private AudioService InstantiateAudioService()
    {
        return _gameFactory
            .Instantiate(AssetsPath.AudioService)
            .GetComponent<AudioService>();
    }

    private void RegisterAudioService(AudioService audioService)
    {
        _allServices
            .RegisterSingle<IAudioService>()
            .To<AudioService>(audioService);
    }
}