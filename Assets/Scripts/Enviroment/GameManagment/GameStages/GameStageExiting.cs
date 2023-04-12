using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStageExiting : GameStageBase
{
    private Transform _player;
    public GameStageExiting(GameController gameController, GameStageFactory gamemodeFactory, string gamemodeName) : base(gameController, gamemodeFactory, gamemodeName) { }



    public override void EnterGameStage()
    {
        _player = _gameController.PlayerStateMachine.transform;
        _player.GetComponent<PlayerStats>().ReduceCorruption(100, true);
        _player.rotation = Quaternion.Euler(0, 0, 0);
        _player.position = Vector3.zero;

        _player.LeanScale(Vector3.one * 0.8f, 0.5f);
        LeanTween.value(_gameController.CanvasGroup.alpha, 0, 1f).setOnUpdate((float val) => { _gameController.CanvasGroup.alpha = val; }).setOnComplete(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().name); });
    }
    public override void CheckGameStageChange()
    {

    }
    public override void ExitGameStage()
    {

    }
}
