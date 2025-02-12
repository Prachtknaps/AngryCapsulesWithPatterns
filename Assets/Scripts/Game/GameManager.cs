using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private IGameState state = null;
    private ScoreManager scoreManager = null;
    private Timer timer = null;
    private float timeDelta = 0.0f;

    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenu = null;

    [Header("Pause Menu")]
    [SerializeField] private GameObject pauseMenu = null;

    [Header("Game GUI")]
    [SerializeField] private GameObject gameGUI = null;
    [SerializeField] private ScoreText scoreText = null;
    [SerializeField] private TimerText timerText = null;
    [SerializeField] private TimerBar timerBar = null;

    [Header("Game Over GUI")]
    [SerializeField] private GameObject gameOverMenu = null;
    [SerializeField] private TextMeshProUGUI highScoreText = null;
    [SerializeField] private TextMeshProUGUI newHighScoreText = null;
    [SerializeField] private TextMeshProUGUI gameScoreText = null;

    [Header("Game")]
    [SerializeField] private WeaponSpawner weaponSpawner = null;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        SetState(new MainMenuState());
        scoreManager = new ScoreManager();
        scoreManager.Attach(scoreText);
        timer = new Timer(60.0f);
        timer.Attach(timerText);
        timer.Attach(timerBar);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (state is RunningState)
        {
            timeDelta += Time.deltaTime;
            if (timeDelta >= 1.0f)
            {
                timeDelta = 0.0f;
                timer.RemoveTime(1.0f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (state is PauseMenuState)
            {
                SetState(new RunningState());
            }
            else if (state is RunningState)
            {
                SetState(new PauseMenuState());
            }
        }
    }

    public static IGameState GetState()
    {
        return Instance?.state;
    }

    public static ScoreManager GetScoreManager()
    {
        return Instance?.scoreManager;
    }

    public static Timer GetTimer()
    {
        return Instance?.timer;
    }

    public static GameObject GetMainMenu()
    {
        return Instance?.mainMenu;
    }

    public static GameObject GetPauseMenu()
    {
        return Instance?.pauseMenu;
    }

    public static GameObject GetGameGUI()
    {
        return Instance?.gameGUI;
    }

    public static GameObject GetGameOverMenu()
    {
        return Instance?.gameOverMenu;
    }

    public static TextMeshProUGUI GetHighScoreText()
    {
        return Instance?.highScoreText;
    }

    public static TextMeshProUGUI GetNewHighScoreText()
    {
        return Instance?.newHighScoreText;
    }

    public static TextMeshProUGUI GetGameScoreText()
    {
        return Instance?.gameScoreText;
    }

    public void SetState(IGameState newState)
    {
        state = newState;
        state.Enter();
    }

    public void StartGame()
    {
        SetState(new RunningState());
        weaponSpawner.SpawnWeapons();
    }

    public void ResumeGame()
    {
        SetState(new RunningState());
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
