using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasicButtons : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject joystick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseOnClick()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        joystick.SetActive(false);
        Time.timeScale = 0f;
    }
    
    public void resumeOnClick()
    {
        pauseButton.SetActive(true);
        joystick.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void mainmenuOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        pauseButton.SetActive(true);
        joystick.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
