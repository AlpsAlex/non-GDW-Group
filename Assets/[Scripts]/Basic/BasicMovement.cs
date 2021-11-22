using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasicMovement : MonoBehaviour
{
    Rigidbody _rigidbody;
    public float speed = 10.0f;

    public GameObject playerCamera;

    private GameObject _character;

    private VariableJoystick _joystick;

    private GameObject victoryMenu;
    private GameObject pauseButton;
    private GameObject spawnPoint;

    //private AudioSource _soundSource;

    private GameObject sceneController;

    private float lstFrameSpeed;


    void Start()
    {
        sceneController = GameObject.Find("SceneController");
        _character = transform.GetChild(0).gameObject;
        Cinemachine.CinemachineFreeLook cmfl =
            playerCamera.transform.GetChild(1).GetComponent<Cinemachine.CinemachineFreeLook>();
        cmfl.LookAt = transform.GetChild(0);
        cmfl.Follow = transform.GetChild(0);

        spawnPoint = GameObject.Find("spawnPoint");
        
        _rigidbody = _character.GetComponent<Rigidbody>();

        VariableJoystick[] getJoystick = playerCamera.GetComponentsInChildren<VariableJoystick>();
        foreach(VariableJoystick variableJoystick in getJoystick)
        {
            if(variableJoystick.name == "Variable Joystick")
            {
                _joystick = variableJoystick;
            }
               
        }

        for (int i = 0; i < playerCamera.transform.GetChild(0).childCount; i++)
        {
            GameObject getObj = playerCamera.transform.GetChild(0).GetChild(i).gameObject;
            if (getObj.name == "PNL_VictoryMenu")
            {
                victoryMenu = getObj;
            }


            if (getObj.name == "BTN_Pause")
            {
                pauseButton = getObj;
            }
        }

        _rigidbody.transform.position = spawnPoint.transform.position;
        sceneController.GetComponent<BasicSoundController>().playSound("CHR_Bounce");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float veloX = Input.GetAxis("Horizontal");
        float veloZ = Input.GetAxis("Vertical");

        if(veloX == 0)
        {
            veloX = _joystick.Horizontal;
        }
        if(veloZ == 0)
        {
            veloZ = _joystick.Vertical;
        }

        Vector3 veloInput = new Vector3(veloX, 0, veloZ);
        veloInput = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) * veloInput;

        if (_rigidbody.velocity.y < -15f)
        {
            sceneController.GetComponent<BasicSoundController>().playSound("CHR_Drop");
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.transform.position = spawnPoint.transform.position;
        }

        //Debug.Log(veloInput);
        //Debug.Log(_rigidbody.transform.position);
        //Debug.Log(_rigidbody.transform.position);

        _rigidbody.AddForce(veloInput * speed);
        volumeControl();

        lstFrameSpeed = _rigidbody.velocity.magnitude;
    }

    // Child->Character->OnCollisionEnter: Character On Collision #returns collider
    public void ChildCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Goal")
        {
            sceneController.GetComponent<BasicSoundController>().pauseSound("BGM");
            sceneController.GetComponent<BasicSoundController>().pauseSound("CHR_Bounce");
            sceneController.GetComponent<BasicSoundController>().playSound("CHR_Victory");
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            Time.timeScale = 0.0f;
            victoryMenu.SetActive(true);
            pauseButton.SetActive(false);
        }

        if(collision.collider.name != "Goal")
        {
            sceneController.GetComponent<BasicSoundController>().playSound("CHR_Bounce");
        }
        
    }

    private void volumeControl()
    {
        sceneController.GetComponent<BasicSoundController>().setSoundVolume("CHR_Bounce", 
            lstFrameSpeed / 4.0f);

        if(isOnGround())
            sceneController.GetComponent<BasicSoundController>().setSoundVolume("CHR_Rolling", 
                lstFrameSpeed / 7.0f);
        
            
        if (!isOnGround())
            sceneController.GetComponent<BasicSoundController>().setSoundVolume("CHR_Rolling", 0.0f);
        
            
    }

    private bool isOnGround()
    {
        return Physics.Raycast(_character.transform.position, Vector3.down, 
            _character.GetComponent<SphereCollider>().radius + 0.1f);
    }
}
