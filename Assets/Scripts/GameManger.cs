using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    [SerializeField] private Canvas deathCanvas;
    [SerializeField] private Canvas gameplayCanvas;
    [SerializeField] private Canvas pauseCanvas;

    public bool showCursor;

    public int ultaPoints;
    private int maxUltraPoints = 350;
    public bool killEnemies = false;

    public int killedEnemies;

    public static GameManger instance;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 0;
        ultaPoints = 0;
        killedEnemies = 0;
        ultaPoints = 0;
    }

    private void Start()
    {
        showCursor = false;
        
        Time.timeScale = 0;

        deathCanvas.enabled = false;
        gameplayCanvas.enabled = false;
        pauseCanvas.enabled = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);

        deathCanvas.enabled = false;
        gameplayCanvas.enabled = true;
        pauseCanvas.enabled = false;

        Time.timeScale = 1;

        showCursor = true;
    }

    public void PauseGame()
    {
        showCursor = false;

        Time.timeScale = 0;

        deathCanvas.enabled = false;
        gameplayCanvas.enabled = false;
        pauseCanvas.enabled = true;
    }

    public void ContinueGame()
    {
        deathCanvas.enabled = false;
        gameplayCanvas.enabled = true;
        pauseCanvas.enabled = false;
        
        Time.timeScale = 1;

        showCursor = true;
    }

    public void PlayerDeath()
    {
        showCursor = false;

        Time.timeScale = 0;

        deathCanvas.enabled = true;
        gameplayCanvas.enabled = false;
        pauseCanvas.enabled = false;
    }

    public void Ulta()
    {
        if (ultaPoints < maxUltraPoints)
        {
            return;
        }
        killEnemies = true;

        StartCoroutine(SnoozeWin());
    }

    private IEnumerator SnoozeWin()
    {
        yield return new WaitForSecondsRealtime(0.7f);

        PlayerDeath();
    }
}
