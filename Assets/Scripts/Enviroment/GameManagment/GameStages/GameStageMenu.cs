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

        _gameController.CanvasGroup.alpha = 0;
        CanvasController.Instance.SwitchScreen("MenuScreen");
        LeanTween.value(_gameController.CanvasGroup.alpha, 1, 0.3f).setOnUpdate((float val) => { _gameController.CanvasGroup.alpha = val; });

        _gameController.PlayerStateMachine.SwitchToTurret();
        _gameController.ScoreController.ToggleScore(false);
        _gameController.EnemySpawner.Switches.MoveToPlayer = false;
    }
    public override void CheckGameStageChange()
    {
        if (_gameController.Switches.Entering) ChangeGameStage(_gameStageFactory.Entering());
        else if (_gameController.Switches.Exit) ChangeGameStage(_gameStageFactory.Exit());
    }
    public override void ExitGameStage()
    {
        _gameController.Switches.Menu = false;
        _gameController.EnemySpawner.Switches.Menu = false;
    }
}
