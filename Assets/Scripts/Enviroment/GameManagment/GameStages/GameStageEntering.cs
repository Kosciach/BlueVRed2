using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageEntering : GameStageBase
{
    public GameStageEntering(GameController gameController, GameStageFactory gamemodeFactory, string gamemodeName) : base(gameController, gamemodeFactory, gamemodeName) { }



    public override void EnterGameStage()
    {
        _gameController.EnemySpawner.enabled = false;
        _gameController.EnemySpawner.Spawn();
        LeanTween.value(_gameController.CanvasGroup.alpha, 0, 0.5f).setOnUpdate((float val) => { _gameController.CanvasGroup.alpha = val; }).setOnComplete(() => { _gameController.Switches.Original = true; });
    }
    public override void CheckGameStageChange()
    {
        if (_gameController.Switches.Original) ChangeGameStage(_gameStageFactory.Original());
    }
    public override void ExitGameStage()
    {
        _gameController.Switches.Entering = false;
    }
}
