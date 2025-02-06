using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private GameState state = GameState.MAIN_MENU;
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
        SetState(GameState.MAIN_MENU);
        scoreManager = new ScoreManager();
        scoreManager.Attach(scoreText);
        timer = new Timer(60.0f);
        timer.Attach(timerText);
        timer.Attach(timerBar);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (state == GameState.RUNNING)
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
            if (state == GameState.PAUSE_MENU)
            {
                SetState(GameState.RUNNING);
            }
            else if (state == GameState.RUNNING)
            {
                SetState(GameState.PAUSE_MENU);
            }
        }
    }

    public GameState GetState()
    {
        return state;
    }

    public void SetState(GameState state)
    {
        this.state = state;

        if (state == GameState.MAIN_MENU)
        {
            mainMenu.SetActive(true);
            pauseMenu.SetActive(false);
            gameGUI.SetActive(false);
            gameOverMenu.SetActive(false);
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (state == GameState.PAUSE_MENU)
        {
            mainMenu.SetActive(false);
            pauseMenu.SetActive(true);
            gameOverMenu.SetActive(false);
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (state == GameState.RUNNING)
        { 
            mainMenu.SetActive(false);
            pauseMenu.SetActive(false);
            gameGUI.SetActive(true);
            gameOverMenu.SetActive(false);
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            mainMenu.SetActive(false);
            pauseMenu.SetActive(false);
            gameGUI.SetActive(false);
            gameOverMenu.SetActive(true);
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            BuildGameOverScreen();
        }
    }

    public ScoreManager GetScoreManager()
    {
        return scoreManager;
    }

    public Timer GetTimer()
    {
        return timer;
    }

    public void StartGame()
    {
        SetState(GameState.RUNNING);
        weaponSpawner.SpawnWeapons();
    }

    public void ResumeGame()
    {
        SetState(GameState.RUNNING);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void BuildGameOverScreen()
    {
        int score = scoreManager.GetScore();
        
        if (!PlayerPrefs.HasKey("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }

        int highscore = PlayerPrefs.GetInt("Highscore");
        
        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        
        highScoreText.text = "Highscore: " + highscore;
        newHighScoreText.text = (score >= highscore) ? "Score: " + score : "";
        gameScoreText.text = (score >= highscore) ? "" : "Score: " + score;
    }
}
