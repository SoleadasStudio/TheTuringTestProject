using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private LevelManager[] levels;

    public static GameManager instance;

    private Gamestate currentState;
    private LevelManager currentLevel;

    private int currentLevelIndex = 0;
    private bool isInputActive = true;

    //Singleton Pattern
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public bool IsInputActive()
    {
        return isInputActive;
    }

    void Start()
    {

        if (levels.Length > 0)
        {
            ChangeStateTo(Gamestate.Briefing, levels[currentLevelIndex]);
        }
    }

    public void ChangeStateTo(Gamestate state, LevelManager level)
    {
        currentState = state;
        currentLevel = level;

        switch (currentState)
        {
            case Gamestate.Briefing:
                StartBriefing();
                break;
            case Gamestate.LevelStart:
                InitiateLevel();
                break;
            case Gamestate.LevelIn:
                RunLevel();
                break;
            case Gamestate.LevelEnd:
                CompletedLevel();
                break;
            case Gamestate.GamerOver:
                GameOver();
                break;
            case Gamestate.GameWin:
                GameWin();
                break;
        }

    }

    private void StartBriefing()
    {
        Debug.Log("Briefing Started!");

        isInputActive = false;

        //TODO
        //set start state

        ChangeStateTo(Gamestate.LevelStart, currentLevel);
    }

    private void InitiateLevel()
    {
        Debug.Log("Level Start");

        isInputActive = true;

        currentLevel.StartLevel();

        ChangeStateTo(Gamestate.LevelIn, currentLevel);

    }

    private void RunLevel()
    {
        Debug.Log("Running Level " + currentLevel.gameObject.name);
    }

    public void CompletedLevel()
    {
        Debug.Log("Level End");

        //goes to next level

        if (currentLevel.isFinalLevel)
        {
            ChangeStateTo(Gamestate.GameWin, currentLevel);
        }
        else
        {
            ChangeStateTo(Gamestate.LevelStart, levels[++currentLevelIndex]);
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over, You Lose");
    }

    private void GameWin()
    {
        Debug.Log("Game Over, You Win!");
    }

    public enum Gamestate
    {
        Briefing,
        LevelStart,
        LevelIn,
        LevelEnd,
        GamerOver,
        GameWin,
    }

}
