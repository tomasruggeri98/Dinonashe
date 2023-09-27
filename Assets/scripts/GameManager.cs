using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameoverscreen;
    [SerializeField] private TMP_Text scoretext;
    [SerializeField] private float initialscrollspeed;

    private int score;
    private float timer;
    private float scrollspeed;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    void Update() 
    {
        updatescore();
        updatespeed();
    }

    public void showgameoverscreen()
    {
        gameoverscreen.SetActive(true);
    }

    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    private void updatescore()
    {
        int scorepersecond = 10;
        timer += Time.deltaTime;
        score = (int)(timer * scorepersecond);
        scoretext.text = string.Format("{0:00000}", score);
    }

    public float getscrollspeed() 
    {
        return scrollspeed;

    }

    private void updatespeed() 
    {
        float speeddivider = 10f;
        scrollspeed = initialscrollspeed + timer / speeddivider;
    }
}
