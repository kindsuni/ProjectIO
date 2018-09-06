using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Button registerButton;
    public Button loginButton;
    public Button playButton;


    public Text playerDisplay;

    private void Start()
    {
        if (DBManager.loggedIn)
        {
            playerDisplay.text = "Player : " + DBManager.username;
        }
        registerButton.interactable = !DBManager.loggedIn;
        loginButton.interactable = !DBManager.loggedIn;
        playButton.interactable = DBManager.loggedIn;
    }

    public void GoRegister()
    {
        SceneManager.LoadScene(1);
    }

    public void GoLogin()
    {
        SceneManager.LoadScene(2);
    }
    public void GoGame()
    {
        SceneManager.LoadScene(3);
    }
}
