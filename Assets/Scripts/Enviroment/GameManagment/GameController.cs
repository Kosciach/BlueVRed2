using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; } 
    private GameStageBase _currentGameStage; public GameStageBase CurrentGameStage { get { return _currentGameStage; } set { _currentGameStage = value; } }
    private GameStageFactory _gameStageFactory;
    [SerializeField] string _currentGameStageName; public string CurrentGameStageName { get { return _currentGameStageName; } set { _currentGameStageName = value; } }



    [Space(20)]
    [Header("====References====")]
    [SerializeField] PlayerStateMachine _playerStateMachine; public PlayerStateMachine PlayerStateMachine { get { return _playerStateMachine; } }
    [SerializeField] EnemySpawner _enemySpawner; public EnemySpawner EnemySpawner { get { return _enemySpawner; } }
    [SerializeField] ScoreController _scoreController; public ScoreController ScoreController { get { return _scoreController; } }
    [SerializeField] CanvasGroup _canvasGroup; public CanvasGroup CanvasGroup { get { return _canvasGroup; } }
    [SerializeField] ShootingScript _playerShootingScript; public ShootingScript PlayerShootingScript { get { return _playerShootingScript; } }



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
        public bool Entering;
        public bool Original;
        public bool Exit;
        public bool Pause;
        public bool GameOver;
        public bool Result;
        public bool Exiting;
    }




    public delegate void GameControllerEvent();
    public static event GameControllerEvent KillAllEnemies;




    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(Instance.gameObject);


        //Game stage
        _gameStageFactory = new GameStageFactory(this);
        _currentGameStage = _gameStageFactory.Menu();
        _currentGameStage.EnterGameStage();
    }
    private void Start()
    {
        //Difficulty 
        _difficultyIndex = PlayerPrefs.GetInt("DifficultyIndex");
        _currentDifficulty = _difficulties[_difficultyIndex];
        _enemiesLeftToSpawnRateIncrease = _currentDifficulty.EnemiesToSpawnRateIncrease;

        CanvasController.Instance.ChangeDifficultyName(_currentDifficulty.DifficultyName);
        _scoreController.SetDifficultyName(_currentDifficulty.DifficultyKey);
    }
    private void Update()
    {
        _currentGameStage.CheckGameStageChange();
    }



    public void SwitchDifficulty()
    {
        _difficultyIndex ++;
        PlayerPrefs.SetInt("DifficultyIndex", _difficultyIndex);
        _difficultyIndex = _difficultyIndex > _difficulties.Length - 1 ? 0 : _difficultyIndex;

        _currentDifficulty = _difficulties[_difficultyIndex];
        _enemiesLeftToSpawnRateIncrease = _currentDifficulty.EnemiesToSpawnRateIncrease;

        CanvasController.Instance.ChangeDifficultyName(_currentDifficulty.DifficultyName);
        _scoreController.SetDifficultyName(_currentDifficulty.DifficultyKey);
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
        _switches.Exiting = true;
    }
    public void StartGame()
    {
        _enemySpawner.Spawn();
        KillAllEnemies();
        _switches.Entering = true;
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
    public void SwitchToMenuFromPause()
    {
        _switches.GameOver = true;
        _playerStateMachine.SwitchToDeath();
    }
    public void SwitchToResult()
    {
        _switches.Result = true;
    }



    private void OnEnable()
    {
        EnemyStats.Death += SpawnRateControll;
        GameControllerInputController.PauseEvent += SwitchPause;
        PlayerStats.Corrupted += SwitchToGameOver;
        PlayerDeathCircle.CircleEnded += SwitchToResult;
    }
    private void OnDisable()
    {
        EnemyStats.Death -= SpawnRateControll;
        GameControllerInputController.PauseEvent -= SwitchPause;
        PlayerStats.Corrupted -= SwitchToGameOver;
        PlayerDeathCircle.CircleEnded -= SwitchToResult;
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
        return new GameStageMenu(_gameController, this, MethodBase.GetCurrentMethod().Name);
    }
    public GameStageBase Original()
    {
        return new GameStageOriginal(_gameController, this, MethodBase.GetCurrentMethod().Name);
    }
    public GameStageBase Exit()
    {
        return new GameStageExitGame(_gameController, this, MethodBase.GetCurrentMethod().Name);
    }
    public GameStageBase Pause()
    {
        return new GameStagePause(_gameController, this, MethodBase.GetCurrentMethod().Name);
    }
    public GameStageBase GameOver()
    {
        return new GameStageGameOver(_gameController, this, MethodBase.GetCurrentMethod().Name);
    }
    public GameStageBase Entering()
    {
        return new GameStageEntering(_gameController, this, MethodBase.GetCurrentMethod().Name);
    }
    public GameStageBase Result()
    {
        return new GameStageResult(_gameController, this, MethodBase.GetCurrentMethod().Name);
    }
    public GameStageBase Exiting()
    {
        return new GameStageExiting(_gameController, this, MethodBase.GetCurrentMethod().Name);
    }
}
