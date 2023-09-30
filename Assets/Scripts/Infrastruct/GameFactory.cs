using UnityEngine;

public class GameFactory
{
    public GameObject CreateScreenLoading() => 
        Instantiate(AssetsPath.SceneCurtainPath);

    public GameObject CreatPlayer() => 
        Instantiate(AssetsPath.PlayerPath);

    public GameObject CreateStartMenu() => 
        Instantiate(AssetsPath.StartMenu);

    public GameObject Instantiate(string namePrefab) => 
        Object.Instantiate(FindPrefab(namePrefab));

    private GameObject FindPrefab(string namePrefab) => 
        Resources.Load<GameObject>(namePrefab);
}