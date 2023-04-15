using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStagePause : GameStageBase
{
    public GameStagePause(GameController gameController, GameStageFactory gamemodeFactory, string gamemodeName) : base(gameController, gamemodeFactory, gamemodeName) { }



    public override void EnterGameStage()
    {
        _gameController.PlayerShootingScript.ToggleShootingFromInput(false);
        Time.timeScale = 0f;
        AudioController.Instance.PauseMusic(true, 0);
        CanvasController.Instance.SwitchScreen("PauseScreen");
    }
    public override void CheckGameStageChange()
    {
        if (!_gameController.Switches.Pause) ChangeGameStage(_gameStageFactory.Original());
        else if (_gameController.Switches.Exit) ChangeGameStage(_gameStageFactory.Exit());
        else if (_gameController.Switches.GameOver) ChangeGameStage(_gameStageFactory.GameOver());
    }
    public override void ExitGameStage()
    {
        AudioController.Instance.PauseMusic(false, 0);
        Time.timeScale = 1f;
        CanvasController.Instance.SwitchScreen("OriginalScreen");
        _gameController.Switches.Pause = false;
    }
}
