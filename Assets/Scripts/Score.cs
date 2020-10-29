using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    GameObject gameManager;
    GameObject ball;

    public GameObject ball5;
    public GameObject ball6;
    public GameObject ball7;

    public Button restartButton;

    public Text scoreText;
    public Text winLostTet;

    public int boardCount;
    public int holeCount;
    public int score;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("manager");
        ball = GameObject.FindGameObjectWithTag("ball");

        restartButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }


    void Update()
    {
        
    }

    public void BoardContact()
	{
        boardCount++;

        if (boardCount == 0 && holeCount == 3)
        {
            score = 6;
            scoreText.text = "Score : 6";
            winLostTet.text = "You Win!";
            restartButton.gameObject.SetActive(true);
            gameManager.GetComponent<GameManager>().start = false;

        }
        else if (boardCount == 1 && holeCount == 3)
        {
            score = 4;
            scoreText.text = "Score : 4";
            winLostTet.text = "You Win!";
            restartButton.gameObject.SetActive(true);
            gameManager.GetComponent<GameManager>().start = false;


        }
        else if (boardCount == 2 && holeCount == 3)
        {
            score = 3;
            scoreText.text = "Score : 3";
            winLostTet.text = "You Win!";
            restartButton.gameObject.SetActive(true);
            gameManager.GetComponent<GameManager>().start = false;

        }
        else
        {
            if ((boardCount + holeCount) == 5)
            {
                score = holeCount + boardCount;
                scoreText.text = "Score : " + holeCount;
                winLostTet.text = "You Lost!";
                restartButton.gameObject.SetActive(true);
                gameManager.GetComponent<GameManager>().start = false;

            }
        }
    }

    void ChangeColor()
	{
        if(holeCount == 1)
		{
            ball5.GetComponent<MeshRenderer>().material.color = Color.green;
		}

        if (holeCount == 2)
        {
            ball6.GetComponent<MeshRenderer>().material.color = Color.green;
        }

        if (holeCount == 3)
        {
            ball7.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }

    public void HoleContact()
    {
        holeCount++;

        ChangeColor();

        if (boardCount == 0 && holeCount == 3)
        {
            score = 6;
            scoreText.text = "Score : 6";
            winLostTet.text = "You Win!";
            restartButton.gameObject.SetActive(true);
            gameManager.GetComponent<GameManager>().start = false;

        }
        else if (boardCount == 1 && holeCount == 3)
        {
            score = 4;
            scoreText.text = "Score : 4";
            winLostTet.text = "You Win!";
            restartButton.gameObject.SetActive(true);
            gameManager.GetComponent<GameManager>().start = false;


        }
        else if (boardCount == 2 && holeCount == 3)
        {
            score = 3;
            scoreText.text = "Score : 3";
            winLostTet.text = "You Win!";
            restartButton.gameObject.SetActive(true);
            gameManager.GetComponent<GameManager>().start = false;

        }
        else
        {
            if ((boardCount + holeCount) == 5)
            {
                score = holeCount + boardCount;
                scoreText.text = "Score : "+ holeCount;
                winLostTet.text = "You Lost!";
                restartButton.gameObject.SetActive(true);
                gameManager.GetComponent<GameManager>().start = false;

            }
        }
    }


    void RestartGame()
	{
        score = 0;
        boardCount = 0;
        holeCount = 0;

        scoreText.text = "";
        winLostTet.text = "";
        restartButton.gameObject.SetActive(false);
        ball.GetComponent<Ball>().ballCount = 0;

        ball.GetComponent<Ball>().gameObject.SetActive(true);
        ball.GetComponent<Ball>().transform.position = new Vector3(-9f, 18.8f, -17.1f);
        ball.GetComponent<Ball>().DesactivateRb();

        ball.GetComponent<Ball>().ball1.SetActive(true);
        ball.GetComponent<Ball>().ball2.SetActive(true);
        ball.GetComponent<Ball>().ball3.SetActive(true);
        ball.GetComponent<Ball>().ball4.SetActive(true);

        ball5.GetComponent<MeshRenderer>().material.color = Color.white;
        ball6.GetComponent<MeshRenderer>().material.color = Color.white;
        ball7.GetComponent<MeshRenderer>().material.color = Color.white;

        StartCoroutine(RestartWait());
	}

    IEnumerator RestartWait()
    {
        yield return new WaitForSeconds(1);
        gameManager.GetComponent<GameManager>().start = true;
    }

}
