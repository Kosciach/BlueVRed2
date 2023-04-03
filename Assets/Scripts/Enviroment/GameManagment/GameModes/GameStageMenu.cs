using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageMenu : GameStageBase
{
    public GameStageMenu(GameController gameController, GameStageFactory gamemodeFactory, string gamemodeName) : base(gameController, gamemodeFactory, gamemodeName) { }



    public override void EnterGameStage()
    {
        _gameController.CanvasController.SwitchScreen(0);
        _gameController.PlayerStateMachine.SwitchToTurret();
        _gameController.ScoreController.ToggleScore(false);
    }
    public override void ExitGameStage()
    {

    }
}
