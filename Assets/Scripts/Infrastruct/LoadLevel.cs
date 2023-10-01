using UnityEngine;

public class LoadLevel
{
    private SceneLoader _sceneLoader;
    private GameFactory _gameFactory;
    private LoadingCurtain _loadingCurtain;

    private const string InitialPointTag = "InitialPoint";

    public LoadLevel(GameFactory gameFactory)
    {
        _gameFactory = gameFactory;
        _sceneLoader = new SceneLoader();
    }


    public void EnterLevel(string nameScene)
    {
        _loadingCurtain = InstantiateLoadingCurtain();
        _loadingCurtain.Show();
        _sceneLoader.ChangeProgress += OnChangeProgress;
        _sceneLoader.Load(nameScene, OnLoaded);
    }

    private void OnChangeProgress(float progress) => 
        _loadingCurtain.UpdateProgress(progress);

    private void OnLoaded()
    {
        InitGameWorld();
        _loadingCurtain.Hide();
        _sceneLoader.ChangeProgress -= OnChangeProgress;
    }

    private void InitGameWorld()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Player player = _gameFactory.CreatPlayer().GetComponent<Player>();
        GameObject spawnObject = GameObject.FindWithTag(InitialPointTag);
        player.transform.position = spawnObject.transform.position;
    }

    private LoadingCurtain InstantiateLoadingCurtain()
    {
        GameObject loadingCurtainPrefab = _gameFactory.CreateScreenLoading();
        return loadingCurtainPrefab.GetComponent<LoadingCurtain>();
    }
}