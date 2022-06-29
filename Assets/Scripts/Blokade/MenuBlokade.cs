using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBlokade : MonoBehaviour
{
    public Text playerDisplay;

    public Button buttonLogin;
    public Button buttonPlay;

    //menampilkan status player bahwa sudah login
    private void Start()
    {
        if (DBManager.LoggedIn)
        {
            playerDisplay.text = "Player: " + DBManager.username;
        }

        buttonLogin.interactable = !DBManager.LoggedIn;
        buttonPlay.interactable = DBManager.LoggedIn;
    }

    public void loginButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }

    public void playButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(6);
    }
}
