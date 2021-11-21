using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpawnPlayer : MonoBehaviour
{
    private GameObject _player;
    private GameObject _playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerLoad = (GameObject)Resources.Load("Player");
        GameObject PlayerCameraLoad = (GameObject)Resources.Load("PlayerCamera");
        //_playerCamera = Instantiate(Resources.Load("Resources/PlayerCamera")) as GameObject;

        _playerCamera = Instantiate(PlayerCameraLoad);
        _player = Instantiate(playerLoad);

        _player.GetComponent<BasicMovement>().playerCamera = _playerCamera;

        GameObject interactiveObj = GameObject.Find("InteractiveObj");
        if (interactiveObj)
        {
            for(int i = 0; i < interactiveObj.transform.childCount; i++)
            {
                interactiveObj.transform.GetChild(i).GetComponent<InterControl>()._player = _player.transform.GetChild(0).gameObject;
            }
        }


        Debug.Log("Prefab Code Loaded");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
