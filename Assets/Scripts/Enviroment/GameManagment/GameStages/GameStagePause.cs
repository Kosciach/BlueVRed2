using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStagePause : GameStageBase
{
    public GameStagePause(GameController gameController, GameStageFactory gamemodeFactory, string gamemodeName) : base(gameController, gamemodeFactory, gamemodeName) { }



    public override void EnterGameStage()
    {
        Time.timeScale = 0f;
        CanvasController.Instance.SwitchScreen("PauseScreen");
    }
    public override void CheckGameStageChange()
    {
        if (!_gameController.Switches.Pause) ChangeGameStage(_gameStageFactory.Original());
        else if (_gameController.Switches.Exit) ChangeGameStage(_gameStageFactory.Exit());
        else if (_gameController.Switches.Menu) ChangeGameStage(_gameStageFactory.Menu());
    }
    public override void ExitGameStage()
    {
        Time.timeScale = 1f;
        CanvasController.Instance.SwitchScreen("OriginalScreen");
        _gameController.Switches.Pause = false;
    }
}
