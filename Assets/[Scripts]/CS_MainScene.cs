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

    

    private AudioSource _clickSound;
    private AudioSource _bgm;

    void Start()
    {
        
        Menu.SetActive(true);
        LevelSelection.SetActive(false);

        for(int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if(child.name == "BTN_Click")
                _clickSound = child.GetComponent<AudioSource>();
            if(child.name == "BGM")
                _bgm = child.GetComponent<AudioSource>();
                
        }
        _bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startOnClick()
    {
        _clickSound.Play();
        SceneManager.LoadScene(2);
    }

    public void exitOnClick()
    {
        _clickSound.Play();
        Application.Quit();
    }

    public void LevelOnClick()
    {
        _clickSound.Play();
        Menu.SetActive(false);
        LevelSelection.SetActive(true);
    }

    public void oneOnClick()
    {
        _clickSound.Play();
        SceneManager.LoadScene(2);
    }
    
    public void twoOnClick()
    {
        _clickSound.Play();
        SceneManager.LoadScene(3);
    }

    public void threeOnClick()
    {
        _clickSound.Play();
        SceneManager.LoadScene(4);
    }

    public void returnOnClick()
    {
        _clickSound.Play();
        //SceneManager.LoadScene(0);
        Menu.SetActive(true);
        LevelSelection.SetActive(false);
    }
}
