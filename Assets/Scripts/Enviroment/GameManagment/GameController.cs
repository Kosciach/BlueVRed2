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
    [SerializeField] DifficultyScript[] _difficulties;
    [SerializeField] int _difficultyIndex;
    [SerializeField] DifficultyScript _currentDifficulty;
    [SerializeField] int _enemiesLeftToSpawnRateIncrease;


    [Space(20)]
    [Header("====Switches====")]
    [SerializeField] SwitchesClass _switches; public SwitchesClass Switches { get { return _switches; } set { _switches = value; } }

    [System.Serializable]
    public class SwitchesClass
    {
        public bool Menu;
        public bool Original;
        public bool Exit;
        public bool Pause;
        public bool GameOver;
    }




    private void Awake()
    {
        if(Instance == null) Instance = this;


        _difficultyIndex = 0;
        _currentDifficulty = _difficulties[_difficultyIndex];
        _canvasController.ChangeDifficultyName(_currentDifficulty.DifficultyName);

        _gameStageFactory = new GameStageFactory(this);
        _currentGameStage = _gameStageFactory.Menu();
        _currentGameStage.EnterGameStage();
    }
    private void Start()
    {
        _enemiesLeftToSpawnRateIncrease = _currentDifficulty.EnemiesToSpawnRateIncrease;
    }
    private void Update()
    {
        _currentGameStage.CheckGameStageChange();
    }



    public void SwitchDifficulty()
    {
        _difficultyIndex ++;
        _difficultyIndex = _difficultyIndex > _difficulties.Length - 1 ? 0 : _difficultyIndex;

        _enemiesLeftToSpawnRateIncrease = _currentDifficulty.EnemiesToSpawnRateIncrease;
        _currentDifficulty = _difficulties[_difficultyIndex];
        _canvasController.ChangeDifficultyName(_currentDifficulty.DifficultyName);
    }
    private void SpawnRateControll()
    {
        _enemiesLeftToSpawnRateIncrease--;
        _enemiesLeftToSpawnRateIncrease = Mathf.Clamp(_enemiesLeftToSpawnRateIncrease, 0, _currentDifficulty.EnemiesToSpawnRateIncrease);

        if (_enemiesLeftToSpawnRateIncrease == 0)
        {
            _enemySpawner.IncreaseSpawnRate(_currentDifficulty.EnemySpawnRateIncrease, _currentDifficulty.MaxEnemySpawnRateIncrease);
            _enemiesLeftToSpawnRateIncrease = _currentDifficulty.EnemiesToSpawnRateIncrease;
        }
    }


    public void SwitchToMainMenu()
    {
        _switches.Menu = true;
    }
    public void SwitchToOriginal()
    {
        _switches.Original = true;
    }
    public void SwitchToExitGame()
    {
        _switches.Exit = true;
    }
    public void SwitchPause()
    {
        _switches.Original = true;
        _switches.Pause = !_switches.Pause;
    }
    public void SwitchToGameOver()
    {
        _switches.GameOver = true;
    }



    private void OnEnable()
    {
        EnemyStats.Death += SpawnRateControll;
        GameControllerInputController.PauseEvent += SwitchPause;
        PlayerStats.Corrupted += SwitchToGameOver;
    }
    private void OnDisable()
    {
        EnemyStats.Death -= SpawnRateControll;
        GameControllerInputController.PauseEvent -= SwitchPause;
        PlayerStats.Corrupted -= SwitchToGameOver;
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
        return new GameStageExitGame(_gameController, this, "Exit");
    }
    public GameStageBase Pause()
    {
        return new GameStagePause(_gameController, this, "Pause");
    }
    public GameStageBase GameOver()
    {
        return new GameStageGameOver(_gameController, this, "GameOver");
    }
}
