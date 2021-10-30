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

    // camera touch movement
    private Vector2 touchPoint1;
    private Vector2 touchMove;
    private Camera _camera;
    private Vector3 cameraPos;
    private float touchMoveSpd = -1f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = GetComponent<Camera>();
        cameraPos = _camera.transform.position;
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

        Debug.Log(veloInput);

        Debug.Log(_rigidbody.transform.position);

        _rigidbody.AddForce(veloInput * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Plane")
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.transform.localPosition = new Vector3(-1f, 22f, -30f);
        }

        if(collision.collider.name == "ExitPlane")
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }

    private void touchScreenCameraMove()
    {
        if (Input.touchCount > 0 && Input.touchCount < 3)
        {
            int rightTouchInd = -1;
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).position.x > 0)
                    rightTouchInd = i;
            }
            if(rightTouchInd >= 0)
            {
                if (Input.GetTouch(rightTouchInd).phase == TouchPhase.Began)
                    touchPoint1 = Input.GetTouch(rightTouchInd).position;

                if (Input.GetTouch(rightTouchInd).phase == TouchPhase.Moved)
                {
                    touchMove.x = Input.GetTouch(rightTouchInd).deltaPosition.x * Time.deltaTime;
                    touchMove.y = Input.GetTouch(rightTouchInd).deltaPosition.y * Time.deltaTime;

                    cameraPos += new Vector3(touchMove.x, touchMove.y, 0) * touchMoveSpd;

                    this.transform.position = cameraPos;
                }
            }
        }
    }
    
}
