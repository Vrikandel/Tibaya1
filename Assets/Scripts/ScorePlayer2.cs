using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScorePlayer2 : MonoBehaviour
{
    [SerializeField] private AudioSource winnerSoundEffect;
    public static ScorePlayer2 instance;

    public Text scoreText2;
    static public int scoreplayer2;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText2.text = "Score:" + scoreplayer2.ToString();
    }

    public void AddScore2()
    {
        scoreplayer2 += 1;
        scoreText2.text = "Score:" + scoreplayer2.ToString();
        if (scoreplayer2 == 2)
        {
            winnerSoundEffect.Play();
            Invoke(nameof(Winner), 1);
        }
    
    }

    private void Winner()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        scoreplayer2 = 0;
    }
}
