using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameStageBase
{
    protected GameController _gameController;
    protected GameStageFactory _gameStageFactory;
    public GameStageBase(GameController gameController, GameStageFactory gameStageFactory, string gameStageName)
    {
        _gameController = gameController;
        _gameStageFactory = gameStageFactory;
        _gameController.CurrentGameStageName = gameStageName;
    }



    public abstract void EnterGameStage();
    public abstract void ExitGameStage();
    public abstract void CheckGameStageChange();
    public void ChangeGameStage(GameStageBase newGameStage)
    {
        ExitGameStage();
        _gameController.CurrentGameStage = newGameStage;
        _gameController.CurrentGameStage.EnterGameStage();
    }
}
