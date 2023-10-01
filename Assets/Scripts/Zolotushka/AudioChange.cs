using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChange : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    private AudioSource _audioSource;
    
    private GameFactory _gameFactory;
    private AllServices _allServices;

    private void Awake()
    {
        _gameFactory = new GameFactory();
        _allServices = new AllServices();

        AudioService audioService = InstantiateAudioService();
        RegisterAudioService(audioService);
        MusicChange();
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

    private void MusicChange()
    {
        var audioService = AllServices.Singleton.Single<IAudioService>();
        audioService.AudioSource.clip = _audioClip;
        audioService.AudioSource.Play();
    }
}
