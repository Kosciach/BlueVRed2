using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageGameOver : GameStageBase
{
    public GameStageGameOver(GameController gameController, GameStageFactory gamemodeFactory, string gamemodeName) : base(gameController, gamemodeFactory, gamemodeName) { }



    public override void EnterGameStage()
    {
        _gameController.EnemySpawner.Switches.GameOver = true;
    }
    public override void CheckGameStageChange()
    {

    }
    public override void ExitGameStage()
    {

    }
}