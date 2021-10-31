using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasicMovement : MonoBehaviour
{
    // get components variable
    Rigidbody _rigidbody;
    public float speed = 10.0f;

    public VariableJoystick variableJoystick;

    public GameObject victoryMenu;
    public GameObject pauseButton;
    public GameObject joystickLeft;

    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player1");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float veloX = Input.GetAxis("Horizontal");
        float veloZ = Input.GetAxis("Vertical");

        if(veloX == 0)
        {
            veloX = variableJoystick.Horizontal;
        }
        if(veloZ == 0)
        {
            veloZ = variableJoystick.Vertical;
        }

        Vector3 veloInput = new Vector3(veloX, 0, veloZ);
        veloInput = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) * veloInput;

        //Debug.Log(veloInput);
        //Debug.Log(_rigidbody.transform.position);
        //Debug.Log(_rigidbody.transform.position);

        _rigidbody.AddForce(veloInput * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Plane")
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.transform.position = new Vector3(-3.5f, 8f, -10f);
 
        }

        if(collision.collider.name == "ExitPlane")
        {
            victoryMenu.SetActive(true);
            pauseButton.SetActive(false);
            joystickLeft.SetActive(false);
        }
    }
}
