using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    private GameStageBase _currentGameStage; public GameStageBase CurrentGameStage { get { return _currentGameStage; } set { _currentGameStage = value; } }
    private GameStageFactory _gameStageFactory;
    [SerializeField] string _currentGameStageName; public string CurrentGameStageName { get { return _currentGameStageName; } set { _currentGameStageName = value; } }



    [Space(20)]
    [Header("====References====")]
    [SerializeField] CanvasController _canvasController; public CanvasController CanvasController { get { return _canvasController; } }
    [SerializeField] PlayerStateMachine _playerStateMachine; public PlayerStateMachine PlayerStateMachine { get { return _playerStateMachine; } }
    [SerializeField] EnemySpawner _enemySpawner; public EnemySpawner EnemySpawner { get { return _enemySpawner; } }
    [SerializeField] ScoreController _scoreController; public ScoreController ScoreController { get { return _scoreController; } }



    [Space(20)]
    [Header("====DifficultyArea====")]
    [SerializeField] int _difficultyIndex;
    [SerializeField] string _difficultyName;




    private void Awake()
    {
        if(Instance == null) Instance = this;

        _gameStageFactory = new GameStageFactory(this);
        _currentGameStage = _gameStageFactory.Menu();
        _currentGameStage.EnterGameStage();
    }


    public void SwitchToMainMenu()
    {
        SwitchGameStage(_gameStageFactory.Menu());
    }
    public void SwitchToOriginal()
    {
        SwitchGameStage(_gameStageFactory.Original());
    }
    public void SwitchToExitGame()
    {
        SwitchGameStage(_gameStageFactory.Exit());
    }
    private void SwitchGameStage(GameStageBase newGameStage)
    {
        _currentGameStage.ExitGameStage();
        _currentGameStage = newGameStage;
        _currentGameStage.EnterGameStage();
    }
}





public class GameStageFactory
{
    private GameController _gameController;

    public GameStageFactory(GameController gameController)
    {
        _gameController = gameController;
    }


    public GameStageBase Menu()
    {
        return new GameStageMenu(_gameController, this, "Menu");
    }
    public GameStageBase Original()
    {
        return new GameStageOriginal(_gameController, this, "Original");
    }
    public GameStageBase Exit()
    {
        return new GameExitGameStage(_gameController, this, "Exit");
    }
}
