using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExitGameStage : GameStageBase
{
    public GameExitGameStage(GameController gameController, GameStageFactory gamemodeFactory, string gamemodeName) : base(gameController, gamemodeFactory, gamemodeName) { }



    public override void EnterGameStage()
    {
        Application.Quit();
    }
    public override void ExitGameStage()
    {

    }
}
