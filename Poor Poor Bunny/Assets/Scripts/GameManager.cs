using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    GameObject bunny, spawner;

    Spawner spawnScript;

    public Animator levelAnim;

    public int score, highScore, level1, level2, level3, currentLevel, currentScore;

    float spawnRate = 1;

    public GameObject startMenu, buttons, instructions, settings, scoreUI, replayPanel, levelUp, menuPanel;
    public Text scoreText;

    VolumeControl sounds;
    public int Score
    {
        set
        {
            score += value;
        }
    }
/*********************************************************************/
    private void Awake()
    {
        bunny = GameObject.Find("rabbit");
        spawner = GameObject.Find("SpikeSpawner");
        spawnScript = spawner.GetComponent<Spawner>();
        sounds = GameObject.Find("GameSounds").GetComponent<VolumeControl>();
    }//Start
    // creates singleton and sets up menu panel
    void Start () {

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        bunny.SetActive(false);
        spawner.SetActive(false);
        startMenu.SetActive(true);
        buttons.SetActive(true);
        instructions.SetActive(false);
        settings.SetActive(false);
        scoreUI.SetActive(false);
        replayPanel.SetActive(false);
        levelUp.SetActive(false);
        score = 0;
        currentLevel = 0;

	}//Awake
    void Update()
    {
        CheckLevel();
        UpdateScore();
        currentScore = score;
    }//Update
     /*---------------Menu Methods---------------------*/
    public void StartGame()
    {
        bunny.SetActive(true);
        spawner.SetActive(true);
        startMenu.SetActive(false);
        scoreUI.SetActive(true);
        replayPanel.SetActive(false);
        score = 0;
        //AddScore(score);
        spawnScript.StartSpawning(1);
    }//Start Game

    public void Instructions()
    {
        buttons.SetActive(false);
        instructions.SetActive(true);
        settings.SetActive(false);
    }//Instructions

    public void ReturnToButtons()
    {
        buttons.SetActive(true);
        instructions.SetActive(false);
        settings.SetActive(false);
        replayPanel.SetActive(false);
    }//ReturnToButtons

    public void SettingsMenu()
    {
        buttons.SetActive(false);
        instructions.SetActive(false);
        settings.SetActive(true);
    }//SettingsMenu
    public void BackToMain()
    {
        replayPanel.SetActive(false);
        startMenu.SetActive(true);
        ReturnToButtons();
    }//BackToMain

    void SetGame(bool set)
    {
        bunny.SetActive(set);
        spawner.SetActive(set);
        //scorePanel.SetActive(set);
    }//SetGame
    /*----------------------------------------*/


    //checking current level and plays appropriate animation on level up
    void CheckLevel()
    {
        if (score >= level1 && currentLevel == 0)
        {
            StartCoroutine(LevelUp());
        }
        else if (score >= level2 && currentLevel == 1)
        {
            StartCoroutine(LevelUp());
        }
        else if (score >= level3 && currentLevel == 2)
        {
            StartCoroutine(LevelUp());
        }
    }//CheckLevel

    IEnumerator LevelUp()
    {
        spawnScript.StopSpawning();
        currentLevel += 1;
        spawnRate -= 0.2f;
        GameObject[] spikes = GameObject.FindGameObjectsWithTag("spike");
        foreach (GameObject item in spikes)
        {
            Destroy(item);
        }

        sounds.LevelUpAudio();
        levelUp.SetActive(true);
        levelAnim.Play("level"+currentLevel);
        yield return new WaitForSeconds(2f);
        spawnScript.StartSpawning(spawnRate);
        levelUp.SetActive(false);
    }//LevelUp

    void UpdateScore()
    {
        scoreText.text = currentScore.ToString();
    }

    public void GameOver()
    {
        spawnScript.StopSpawning();
        GameObject[] spikes = GameObject.FindGameObjectsWithTag("spike");
        foreach (GameObject item in spikes)
        {
            Destroy(item);
        }
        replayPanel.SetActive(true);
        scoreUI.SetActive(false);
        levelUp.SetActive(false);
        currentLevel = 0;
        spawnRate = 1f;
        score = 0;
    }//GameOver


}
