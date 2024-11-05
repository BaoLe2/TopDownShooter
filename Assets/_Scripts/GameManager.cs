using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : BaoMonoBehaviour
{
    public bool startGame;
    public GameObject panelTap;
    public Transform panelPause;
    protected static GameManager instance;
    public static GameManager Instance { get => instance; }
    public Transform mainCamera;
    public GameObject audioOver;
    public AudioSource musicBackgound;
    protected bool gameOver;
    public bool gameOver2 = false;
    public bool GameOver { get => gameOver; set => gameOver = value; }
    protected bool win;
    public bool Win { get => win; set => win = value; }
    public GameObject textGameWin;
    public GameObject gameOverPanel;
    public GameObject audioWinner;
    public GameObject uppgradeButton;
    public GameObject pauseButton;

    protected override void Awake()
    {
        if (GameManager.instance != null) Debug.Log("Only 1 GameManager");
        GameManager.instance = this;
        this.uppgradeButton.SetActive(false);
        this.pauseButton.SetActive(false);
    }

    protected override void Update()
    {
        this.GameOvering();
        this.Wining();
        if(this.gameOver)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    protected bool IsGameOver()
    {
        if (this.gameOver == true && this.gameOver2 == true) return true;
        return false;
    }

    protected void GameOvering()
    {
        if (!this.IsGameOver()) return;
        this.audioOver.SetActive(true);
        this.musicBackgound.Stop();
        this.gameOverPanel.SetActive(true);
        this.pauseButton.SetActive(false);
        this.uppgradeButton.SetActive(false);
    }

    protected bool IsWin()
    {
        if (!this.win) return false;
        return true;
    }

    protected void Wining()
    {
        if (!this.IsWin()) return;
        this.WinGame();
    }

    protected void WinGame()
    {
        this.musicBackgound.Stop();
        this.textGameWin.SetActive(true);
        this.audioWinner.SetActive(true);
    }

    public void Pause()
    {
        this.panelPause.transform.gameObject.SetActive(true);
        this.gameOver = true;
        this.uppgradeButton.SetActive(false);
    }

    public void Continue()
    {
        this.panelPause.transform.gameObject.SetActive(false);
        this.gameOver = false;
        this.uppgradeButton.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Replay(){
        SceneManager.LoadScene(0);
        this.gameOver = false;
    }

    public void StartGame()
    {
        this.startGame = true;
        this.panelTap.SetActive(false);
        this.uppgradeButton.SetActive(true);
        this.pauseButton.SetActive(true);
    }
}
