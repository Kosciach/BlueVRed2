using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageExitGame : GameStageBase
{
    public GameStageExitGame(GameController gameController, GameStageFactory gamemodeFactory, string gamemodeName) : base(gameController, gamemodeFactory, gamemodeName) { }



    public override void EnterGameStage()
    {
        Application.Quit();
    }
    public override void CheckGameStageChange()
    {

    }
    public override void ExitGameStage()
    {

    }
}
