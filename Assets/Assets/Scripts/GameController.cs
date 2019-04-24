using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    
    public AudioSource audioClip;
    public AudioSource audioClip2;
    public Rigidbody rb;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text creationText;
    public Text speedText;

        
    private bool gameOver;
    private bool restart;
    private int score;


    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        creationText.text = "";
        speedText.text = "";

        score = 0;
        UpdateScore();

    
        StartCoroutine (SpawnWaves ());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene("Space Shooter");
        }
        {
        if (Input.GetKey("escape"))
                Application.Quit();
        }

    }


    IEnumerator SpawnWaves()
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);

                if (gameOver)
                {
                    restartText.text = "'N' for Restart";
                    restart = true;
                    break;
                }
            }
        }
 
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();

     }

    void UpdateScore()
    {
        speedText.text = "Collect the balls to increase your player speed!";
        ScoreText.text = "Points: " + score;
            if (score >= 100)
            {
                winText.text = "You Win!";
                creationText.text = "Game created by Joi Miller";
                gameOver = true;
                restart = true;
                audioClip.Play();
        }
    }
    public void GameOver ()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        audioClip2.Play();
    }
}
