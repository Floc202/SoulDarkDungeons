using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public int level;
    void Start()
    {
    }

    // Update is called once per frame
    public void OpenScene()
    {
        SceneManager.LoadScene("Level-0" + level.ToString());
    }
    public void BackScene()
    {
        SceneManager.LoadScene(0);
    }
}
