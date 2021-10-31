using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasicButtons : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject joystickLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Pause Menu
    public void pauseOnClick()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        joystickLeft.SetActive(false);
        Time.timeScale = 0f;
    }
    
    public void resumeOnClick()
    {
        pauseButton.SetActive(true);
        joystickLeft.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void mainmenuOnClick()
    {
        pauseButton.SetActive(true);
        joystickLeft.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    // Victory Menu
    public void goNextOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void retryOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
