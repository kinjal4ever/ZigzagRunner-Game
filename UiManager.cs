using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject zigzagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;

    public Text score;
    public Text highScore_MainScreen;
    public Text highScore_GameOver;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore_MainScreen.text = "High Score:" + PlayerPrefs.GetInt("highscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        highScore_MainScreen.text = "High Score:"+PlayerPrefs.GetInt("highscore").ToString();
        tapText.SetActive(false);
        //zigzagPanel.SetActive(true);
        zigzagPanel.GetComponent<Animator>().Play("panelUp"); 
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverPanel.GetComponent<Animator>().Play("gameOverPanelAppear");
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore_GameOver.text = PlayerPrefs.GetInt("highscore").ToString();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
        Debug.Log("scene is");
    }
}
