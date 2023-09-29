using UnityEngine;

public class GameBootstraper : MonoBehaviour
{
    [SerializeField] private StartMenu _startMenu;
    private GameFactory _gameFactory;

    private void Awake()
    {
        _gameFactory = new GameFactory();
        _startMenu.Construct(_gameFactory);
    }
}
