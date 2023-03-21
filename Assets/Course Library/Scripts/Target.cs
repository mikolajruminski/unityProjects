using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;

    private GameManager gameManager;

    private float maxTorque= 10;
    private float minSpeed = 14;
    private float maxSpeed = 18;
    private float xRange = 4;
    private float ySpawnPos = -6;

    private int score = 5;
    private int minusLives = 1;

    private int noLives = 2;
    public int pointValue;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(),RandomTorque(), ForceMode.Impulse);

        transform.position = randomPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce () {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque () {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 randomPos () {
     return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (gameManager.isGameActive) {
        Destroy(gameObject);
        gameManager.updateScore(-score);
        }

        if (!gameObject.CompareTag("Bad") && gameManager.isGameActive) {
            gameManager.livesNumber -= minusLives;
            gameManager.lives[gameManager.livesNumber].gameObject.SetActive(false);
     }

     if (gameManager.livesNumber < noLives) {
            gameManager.gameOver();
        }
    }

    
       
       public void DestroyTarget() {

        if (gameManager.isGameActive){
        Destroy(gameObject);
        gameManager.updateScore(pointValue);
        Instantiate(explosionParticle, transform.position, transform.rotation);
       }
       }   
}
