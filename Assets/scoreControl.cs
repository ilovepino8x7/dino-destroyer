using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
public class scoreControl : MonoBehaviour
{

    public int playerScore = 0;
    public TMP_Text scoreText;
    public bool gamePlaying = true;
    public GameObject gos;
    public GameObject start;
    public GameObject crusher;

    void Start()
    {

    }
    // Display score
    void Update()
    {
        scoreText.text = playerScore.ToString();
        if (playerScore < -15)
        {
            gamePlaying = false;
            crusher.SetActive(false);
            gos.SetActive(true);
        }
        if (Input.GetKeyDown("r"))
        {
            restartGame();
        }
    }

    // Gain Score
    public void gainScore()
    {
        playerScore += 1;
    }

    public void loseScore()
    {
        playerScore -= 1;
    }
    public void superGainScore()
    {
        playerScore += 5;
    }
    public void superLoseScore()
    {
        playerScore -= 5;
    }
    public void restartGame()
    {
        gos.SetActive(false);
        SceneManager.LoadScene("GameScene");;
        crusher.SetActive(true);
        gamePlaying = true;
    }

    
}
