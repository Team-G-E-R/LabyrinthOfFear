using UnityEngine;

public class GameFactory
{
    public GameObject CreateScreenLoading() => 
        Instantiate(AssetsPath.SceneCurtainPath);

    private GameObject Instantiate(string namePrefab) => 
        FindPrefab(namePrefab);

    private GameObject FindPrefab(string namePrefab) => 
        Resources.Load<GameObject>(namePrefab);

    public GameObject CreatPlayer() => 
        Resources.Load<GameObject>(AssetsPath.PlayerPath);
}