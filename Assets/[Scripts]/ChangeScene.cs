using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene: MonoBehaviour
{
    private int levelNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeToCurrentGame()
    {
        SceneManager.LoadScene(2);
    }

    public void nextLevel()
    {
        
    }
}
