using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CS_MainScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Menu;
    public GameObject LevelSelection;

    void Start()
    {
        Menu.SetActive(true);
        LevelSelection.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startOnClick()
    {
        SceneManager.LoadScene(2);
    }

    public void exitOnClick()
    {
        Application.Quit();
    }

    public void LevelOnClick()
    {
        Menu.SetActive(false);
        LevelSelection.SetActive(true);
    }

    public void oneOnClick()
    {
        SceneManager.LoadScene(2);
    }
    
    public void twoOnClick()
    {
        SceneManager.LoadScene(3);
    }

    public void returnOnClick()
    {
        SceneManager.LoadScene(0);
        Menu.SetActive(true);
        LevelSelection.SetActive(false);
    }
}
