using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageOriginal : GameStageBase
{
    public GameStageOriginal(GameController gameController, GameStageFactory gamemodeFactory, string gamemodeName) : base(gameController, gamemodeFactory, gamemodeName) { }



    public override void EnterGameStage()
    {
        CanvasController.Instance.SwitchScreen("OriginalScreen");
        LeanTween.value(_gameController.CanvasGroup.alpha, 1, 0.5f).setOnUpdate((float val) => { _gameController.CanvasGroup.alpha = val; }).setOnComplete(() =>
        {
            _gameController.PlayerStateMachine.SwitchToMoveShoot();
            _gameController.ScoreController.ToggleScore(true);
            _gameController.EnemySpawner.enabled = true;
            _gameController.EnemySpawner.Switches.MoveToPlayer = true;
        });
    }
    public override void CheckGameStageChange()
    {
        if (_gameController.Switches.Pause) ChangeGameStage(_gameStageFactory.Pause());
        else if (_gameController.Switches.GameOver) ChangeGameStage(_gameStageFactory.GameOver());
    }
    public override void ExitGameStage()
    {
        _gameController.Switches.Original = false;
        _gameController.EnemySpawner.Switches.MoveToPlayer = false;
    }
}
