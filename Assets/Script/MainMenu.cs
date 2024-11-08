using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Nhớ thêm thư viện này để làm việc với UI

public class MainMenu : MonoBehaviour
{
    public int Screen;

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player Has Quit The Game");
    }

    public void OpenScene()
    {
        SceneManager.LoadScene(8);
    }

    public void BackScene()
    {
        SceneManager.LoadScene(0);
    }
}
