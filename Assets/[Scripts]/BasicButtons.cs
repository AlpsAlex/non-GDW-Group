using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasicButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(100, 100, 70, 30), "PAUSE"))
        {
            SceneManager.LoadScene("PauseScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
