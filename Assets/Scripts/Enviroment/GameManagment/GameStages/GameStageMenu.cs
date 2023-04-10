using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStageMenu : GameStageBase
{
    public GameStageMenu(GameController gameController, GameStageFactory gamemodeFactory, string gamemodeName) : base(gameController, gamemodeFactory, gamemodeName) { }



    public override void EnterGameStage()
    {
        Time.timeScale = 1;
        CanvasController.Instance.SwitchScreen("MenuScreen");
        _gameController.PlayerStateMachine.SwitchToTurret();
        _gameController.ScoreController.ToggleScore(false);
        _gameController.EnemySpawner.Switches.MoveToPlayer = false;
    }
    public override void CheckGameStageChange()
    {
        if (_gameController.Switches.Original) ChangeGameStage(_gameStageFactory.Original());
        else if (_gameController.Switches.Exit) ChangeGameStage(_gameStageFactory.Exit());
    }
    public override void ExitGameStage()
    {
        _gameController.Switches.Menu = false;
        _gameController.EnemySpawner.Switches.Menu = false;
    }
}
