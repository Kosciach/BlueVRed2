using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gamemode_Base
{
    protected GameController _gameController;
    protected GamemodeFactory _gamemodeFactory;
    public Gamemode_Base(GameController gameController, GamemodeFactory gamemodeFactory, string gamemodeName)
    {
        _gameController = gameController;
        _gamemodeFactory = gamemodeFactory;
        _gameController.CurrentGamemodeName = gamemodeName;
    }



    public abstract void EnterGamemode();
    public abstract void ExitGamemode();
    public void ChangeGamemode(Gamemode_Base newGamemode)
    {
        ExitGamemode();
        _gameController.CurrentGamemode = newGamemode;
        _gameController.CurrentGamemode.EnterGamemode();
    }
}
