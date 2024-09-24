using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private MainWindow _mainWindow;
    [SerializeField] private StartWindow _startWindow;
    [SerializeField] private GameOverWindow _endWindow;
    [SerializeField] private WinWindow _winWindow;

    [SerializeField] private Player _player;
    [SerializeField] private SplineFolower _splineFolower;


    private void Awake()
    {
        _startWindow.Init();
        _mainWindow.Init();
    }

    private void OnEnable()
    {
        _splineFolower.MouseMoved += OnMouseMove;

        _player.GameOver += OnGameOver;
        _player.LevelComplete += OnFinish;

    }

    private void OnDisable()
    {
        _splineFolower.MouseMoved -= OnMouseMove;

        _player.LevelComplete -= OnFinish;
        _player.GameOver -= OnGameOver;

        _winWindow.RestartButton.onClick?.RemoveListener(OnGameRestart);
        _endWindow.RestartButton.onClick?.RemoveListener(OnGameRestart);
    }

    private void OnMouseMove()
    {
        _startWindow.Finish();
        Cursor.visible = false;
    }

    private void OnGameOver()
    {
        Cursor.visible = true;

        _splineFolower.StopMoving();
        _splineFolower.enabled = false;

        _mainWindow.Finish();

        _endWindow.Init();

        _endWindow.RestartButton.onClick.AddListener(OnGameRestart);
    }

    private void OnGameRestart()
    {
        _endWindow.Finish();
        _winWindow.Finish();

        _startWindow.Init();
        _mainWindow.Init();
        _player.Restart();

        _splineFolower.enabled = true;
    }

    private void OnFinish()
    {
        Cursor.visible = true;

        _splineFolower.enabled = false;

        _mainWindow.Finish();

        _winWindow.Init();

        _winWindow.RestartButton.onClick.AddListener(OnGameRestart);
    }
}
