using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private LoadLevel _loadLevel;

    public void Construct(GameFactory gameFactory)
    {
        _loadLevel = new LoadLevel(gameFactory);
    }

    public void StartGame()
    {
        _loadLevel.EnterLevel("TestView");
    }
}
