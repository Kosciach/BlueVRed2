using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageResult : GameStageBase
{
    public GameStageResult(GameController gameController, GameStageFactory gamemodeFactory, string gamemodeName) : base(gameController, gamemodeFactory, gamemodeName) { }



    public override void EnterGameStage()
    {
        CanvasController.Instance.SwitchScreen("ResultScreen");
        LeanTween.value(_gameController.CanvasGroup.alpha, 1, 0.5f).setOnUpdate((float val) => { _gameController.CanvasGroup.alpha = val; });
    }
    public override void CheckGameStageChange()
    {

    }
    public override void ExitGameStage()
    {

    }
}
