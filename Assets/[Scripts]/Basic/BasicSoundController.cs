using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSoundController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound(string soundName)
    {
        for(int i = 0; i < transform.childCount; i ++)
        {
            Transform child = transform.GetChild(i);
            if(child.name == soundName)
            {
                child.GetComponent<AudioSource>().Play();
                break;
            }
        }
    }

    public void pauseSound(string soundName)
    {
        for(int i = 0;i < transform.childCount;i ++)
        {
            Transform child = transform.GetChild(i);
            if (child.name == soundName)
            {
                child.GetComponent<AudioSource>().Pause();
                break;
            }
        }
    }

    public void setSoundVolume(string soundName, float volume)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.name == soundName)
            {
                child.GetComponent<AudioSource>().volume = volume;
                break;
            }
        }
    }
}
