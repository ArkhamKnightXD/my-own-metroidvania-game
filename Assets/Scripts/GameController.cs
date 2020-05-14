using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int CurrentScore;

    public int CurrentLives;

    public float CurrentTime;

    public TextMesh ScoreText;

    public TextMesh LivesText;

    public TextMesh TimerText;

    public GameObject GameOverText;

    public GameObject WinText;

    public GameObject Player;

    public GameObject Timer;

    int countTimer = 0;


    void Start()
    {
        AudioController.Instance.PlaySoundEffect(AudioController.SoundEffect.Song);

        CurrentScore = 0;
        CurrentLives = 100;
        CurrentTime = 10;

        LivesText = GameObject.Find("LivesText").GetComponent<TextMesh>();
        TimerText = GameObject.Find("TimerText").GetComponent<TextMesh>();
        GameOverText = GameObject.Find("GameOverText");
        WinText = GameObject.Find("WinText");
        Timer = GameObject.Find("TimerText");

        GameOverText.SetActive(false);
        WinText.SetActive(false);
        Timer.SetActive(false);
        
    }


    void Update()
    {
        if (Player.gameObject.CompareTag("Explosion"))
        {
            DecrementTime();   
        }
    
    }


    public int IncrementScore()
    {

        CurrentScore += 50;

        ScoreText.text = CurrentScore.ToString();

        return CurrentScore;
    }


    public int IncrementLives()
    {

        CurrentLives++;
       
        LivesText.text = $"{CurrentLives}"; 

        return CurrentLives;
    }



    public void Win()
    {

        StartCoroutine("SendScore");

        WinText.SetActive(true);

        AudioController.Instance.PlaySoundEffect(AudioController.SoundEffect.Win);

    }

    
    public int DecrementLives()
    {
        CurrentLives = CurrentLives > 0 ? CurrentLives - 1 : 0;
       
        LivesText.text = $"{CurrentLives}"; 


        if (CurrentLives == 0)
        {

            StartCoroutine("SendScore");

            GameOverText.SetActive(true);

            AudioController.Instance.PlaySoundEffect(AudioController.SoundEffect.GameOver);
            
        }

        return CurrentLives;
    }


    public float DecrementTime()
    {
        
        CurrentTime = CurrentTime > 0 ? CurrentTime - 1 * Time.deltaTime : 0;

        Timer.SetActive(true);

        TimerText.text = CurrentTime.ToString("0");

        if (CurrentTime == 0 && countTimer == 0)
        {
            countTimer++;

            StartCoroutine("SendScore");

            GameOverText.SetActive(true);

            Player.gameObject.tag = "Death";

            AudioController.Instance.PlaySoundEffect(AudioController.SoundEffect.GameOver);
            
        }
       
        return CurrentTime;
    }


    IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<WebServiceClient>().SendWebRequest(CurrentScore);
    }
}
