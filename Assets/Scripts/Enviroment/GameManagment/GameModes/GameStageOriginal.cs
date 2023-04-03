using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageOriginal : GameStageBase
{
    public GameStageOriginal(GameController gameController, GameStageFactory gamemodeFactory, string gamemodeName) : base(gameController, gamemodeFactory, gamemodeName) { }



    public override void EnterGameStage()
    {
        _gameController.CanvasController.SwitchScreen(1);
        _gameController.PlayerStateMachine.SwitchToMoveShoot();
        _gameController.ScoreController.ToggleScore(true);
    }
    public override void ExitGameStage()
    {

    }
}
