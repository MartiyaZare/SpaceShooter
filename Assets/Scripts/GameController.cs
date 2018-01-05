using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;
    public int score;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        updateScore();
        StartCoroutine(spawnWaves());
    }

    private void Update()
    {
        if (restart) {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator spawnWaves() {
        yield return new WaitForSeconds(startWait);
        while(true) { 
            for ( int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            //if (gameOver) {
            //    restartText.text = "Press 'R' for Restart";
            //    restart = true;
            //    break;
            //}
        }
    }

    public void addScore(int newScoreValue)
    {
        score += newScoreValue;
        updateScore();
    }

    void updateScore()
    {
        scoreText.text = "score " + score;
    }

    public void GameOver()
    {
        //gameOverText.text = "Game Over!";
        gameOver = true;
    }

    public bool isGameOvered()
    {
        bool res = gameOver;
        gameOver = false;
        return res;
    }

    public bool restartGame()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        updateScore();
        //Start();
        //Application.LoadLevel(Application.loadedLevel);
        return true;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
