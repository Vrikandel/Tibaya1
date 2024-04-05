using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Mainmenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -2);
    }

    public void MainMenu2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -3);
    }
}
