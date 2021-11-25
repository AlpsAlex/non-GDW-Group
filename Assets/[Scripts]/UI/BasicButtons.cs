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
    public Slider sldBgmVolume;
    public Slider sldGpVolume;

    private GameObject sceneController;

    // Start is called before the first frame update
    void Start()
    {
        sceneController = GameObject.Find("SceneController");
        bgmSliderOnSlide();
        gPlaySliderOnSlide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Pause Menu
    public void pauseOnClick()
    {
        sceneController.GetComponent<BasicSoundController>().playSound("BTN_Click");
        sceneController.GetComponent<BasicSoundController>().pauseSound("BGM");
        sceneController.GetComponent<BasicSoundController>().pauseSound("CHR_Rolling");
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        joystickLeft.SetActive(false);
        Time.timeScale = 0f;
    }
    
    public void resumeOnClick()
    {
        sceneController.GetComponent<BasicSoundController>().playSound("BTN_Click");
        sceneController.GetComponent<BasicSoundController>().playSound("BGM");
        sceneController.GetComponent<BasicSoundController>().playSound("CHR_Rolling");
        pauseButton.SetActive(true);
        joystickLeft.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void mainmenuOnClick()
    {
        sceneController.GetComponent<BasicSoundController>().playSound("BTN_Click");
        pauseButton.SetActive(true);
        joystickLeft.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    // Victory Menu
    public void goNextOnClick()
    {
        sceneController.GetComponent<BasicSoundController>().playSound("BTN_Click");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void retryOnClick()
    {
        sceneController.GetComponent<BasicSoundController>().playSound("BTN_Click");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void bgmSliderOnSlide()
    {
        float volume = sldBgmVolume.value;
        sceneController.GetComponent<BasicSoundController>().setSoundVolume("BGM", volume);
    }

    public void gPlaySliderOnSlide()
    {
        float volume = sldGpVolume.value;
        sceneController.GetComponent<BasicSoundController>().setSoundVolume("BTN_Click", volume);
        sceneController.GetComponent<BasicSoundController>().setSoundVolume("CHR_Rolling", volume);
        sceneController.GetComponent<BasicSoundController>().setSoundVolume("CHR_Victory", volume);
        sceneController.GetComponent<BasicSoundController>().setSoundVolume("CHR_Drop", volume);
        sceneController.GetComponent<BasicSoundController>().setSoundVolume("CHR_Bounce", volume);
    }
}
