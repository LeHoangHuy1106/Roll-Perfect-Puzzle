using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void PlayGame()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 0);
        }
        SceneManager.LoadScene("PlayScene");

    }

}
