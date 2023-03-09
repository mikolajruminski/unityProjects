using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{    
    public List <GameObject> targets;
    public TextMeshProUGUI scoreText;
    public GameObject titleScreen;
    public GameObject [] lives;
    public GameObject livesObject;
    public Button restartButton;

    public int livesNumber;
    
    public AudioSource audioSource;
    public Slider volumeSlider;
    
    public TextMeshProUGUI gameOverText;
    public int score;
    private float spawnRate = 1.0f;

    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
         livesNumber = 4;
         
         audioSource.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnEnemies () {
        
       while (isGameActive) {

        yield return new WaitForSeconds(spawnRate);
        int randomEnemy = Random.Range(0, targets.Count);
        Instantiate(targets[randomEnemy]);
       }
    }

    public void updateScore(int addScore) {
        score += addScore;
        scoreText.text = "Score: " + score;
    }
    
    public void gameOver() {
        gameOverText.gameObject.SetActive(true);  
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void GameResatart () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   public void StartGame(int difficulty) {
        isGameActive = true;
        livesObject.gameObject.SetActive(true);
        score = 0;
        spawnRate /= difficulty;
        StartCoroutine(spawnEnemies());
        updateScore(0);
        titleScreen.gameObject.SetActive(false);
        volumeSlider.gameObject.SetActive(false);
    }
}
