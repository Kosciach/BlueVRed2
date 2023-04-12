using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageGameOver : GameStageBase
{
    public GameStageGameOver(GameController gameController, GameStageFactory gamemodeFactory, string gamemodeName) : base(gameController, gamemodeFactory, gamemodeName) { }



    public override void EnterGameStage()
    {
        LeanTween.value(_gameController.CanvasGroup.alpha, 0, 0.2f).setOnUpdate((float val) => { _gameController.CanvasGroup.alpha = val; });
        _gameController.EnemySpawner.Switches.GameOver = true;
        _gameController.EnemySpawner.enabled = false;
    }
    public override void CheckGameStageChange()
    {
        if (_gameController.Switches.Result) ChangeGameStage(_gameStageFactory.Result());
    }
    public override void ExitGameStage()
    {
        _gameController.Switches.GameOver = false;
    }
}
