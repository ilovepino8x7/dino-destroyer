using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class start : MonoBehaviour
{
    public int playerScore = 0;
    public TMP_Text scoreText;
    public bool gamePlaying = true;
    public GameObject gos;
    public GameObject starte;
    public GameObject crusher;
    // Update is called once per frame


    void Start()
    {
        
    }
    void Update()
    {

    }
    public void restartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
