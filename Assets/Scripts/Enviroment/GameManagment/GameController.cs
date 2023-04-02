using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Gamemode_Base _currentGamemode; public Gamemode_Base CurrentGamemode { get { return _currentGamemode; } set { _currentGamemode = value; } }
    private GamemodeFactory _gamemodeFactory;
    [SerializeField] string _currentGamemodeName; public string CurrentGamemodeName { get { return _currentGamemodeName; } set { _currentGamemodeName = value; } }




    private void Awake()
    {
        _gamemodeFactory = new GamemodeFactory(this);
        _currentGamemode = _gamemodeFactory.Original();
        _currentGamemode.EnterGamemode();
    }
}





public class GamemodeFactory
{
    private GameController _gameController;

    public GamemodeFactory(GameController gameController)
    {
        _gameController = gameController;
    }



    public Gamemode_Base Original()
    {
        return new Gamemode_Original(_gameController, this, "Original");
    }
}
