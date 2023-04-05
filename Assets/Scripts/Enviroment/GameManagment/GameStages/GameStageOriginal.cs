using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageOriginal : GameStageBase
{
    public GameStageOriginal(GameController gameController, GameStageFactory gamemodeFactory, string gamemodeName) : base(gameController, gamemodeFactory, gamemodeName) { }



    public override void EnterGameStage()
    {
        _gameController.CanvasController.SwitchScreen("OriginalScreen");
        _gameController.PlayerStateMachine.SwitchToMoveShoot();
        _gameController.ScoreController.ToggleScore(true);
        _gameController.EnemySpawner.Switches.MoveToPlayer = true;
    }
    public override void CheckGameStageChange()
    {
        if (_gameController.Switches.Pause) ChangeGameStage(_gameStageFactory.Pause());
    }
    public override void ExitGameStage()
    {
        _gameController.Switches.Original = false;
    }
}
