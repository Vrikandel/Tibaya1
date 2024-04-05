using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScorePlayer1 : MonoBehaviour
{
    [SerializeField] private AudioSource winnerSoundEffect;
    public static ScorePlayer1 instance;

    public Text scoreText;
    static public int scoreplayer1 = 0;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        scoreText.text = "Score: " + scoreplayer1.ToString();
    }

    public void AddScore()
    {
        
        scoreplayer1 += 1;
        scoreText.text = "Score: " + scoreplayer1.ToString();
        if (scoreplayer1 == 2)
        {
            winnerSoundEffect.Play();
            Invoke(nameof(Winner), 1);
        }
    }  

    private void Winner()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            scoreplayer1 = 0;
        }
}

