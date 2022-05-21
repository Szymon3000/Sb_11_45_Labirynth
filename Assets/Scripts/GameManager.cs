using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] int timeToEnd;
    bool gamePaused = false,
        endGame = false,
        win = false;
    public int points = 0;
    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;
    public AudioSource audioSource;
    public AudioClip pauseGame;
    public AudioClip resumeGame;
    public AudioClip winClip;
    public AudioClip loseClip;
    musicScript musicManager;
    bool isLessTimeOn = false;
    void Start()
    {
        if (gameManager == null)
            gameManager = this;

        if (timeToEnd <= 0)
            timeToEnd = 100;

        InvokeRepeating("Stopper", 2, 1);
        audioSource = GetComponent<AudioSource>();
        musicManager = GetComponentInChildren<musicScript>();
        PlayClip(resumeGame);
    }

    void Update()
    {
        PauseCheck();
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd} s");
        if(timeToEnd<20&&!isLessTimeOn)
        {
            isLessTimeOn = true;
            LessTimeOn();
        }
        if(timeToEnd>20&&isLessTimeOn)
        {
            isLessTimeOn = false;
            LessTimeOff();
        }
        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if (endGame)
            EndGame();
    }

    public void PauseGame()
    {
        PlayClip(pauseGame);
        musicManager.OnGamePaused();
        Debug.Log("Game Paused");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        PlayClip(resumeGame);
        Time.timeScale = 1f;
        musicManager.OnGameResumed();
        gamePaused = false;

    }

    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        musicManager.OnGamePaused();
        if (win)
        {
            Debug.Log("You win! Reload?");
            PlayClip(winClip);
        }
        else
        {
            Debug.Log("You lose! Reload?");
            PlayClip(loseClip);
        }
    }
    public void AddPoints(int point)
    {
        points += point;
    }
    public void AddTime(int time)
    {
        timeToEnd += time;
    }
    public void FreezeTime(int freeze)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freeze, 1);
    }
    public void AddKey(KeyColor keyColor)
    {
        switch (keyColor)
        {
            case KeyColor.Red:
                redKey++;
                break;
            case KeyColor.Green:
                greenKey++;
                break;
            case KeyColor.Gold:
                goldKey++;
                break;
        }
    }
    public void PlayClip(AudioClip audioclip)
    {
        audioSource.clip = audioclip;
        audioSource.Play();
    }
    public void LessTimeOn()
    {
        musicManager.Pitch(1.5f);
    }
    public void LessTimeOff()
    {
        musicManager.Pitch(1.5f);
    }
}
