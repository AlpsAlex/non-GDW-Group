using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
     // camera touch movement
    private Vector2 touchPoint1;
    private Vector2 touchMove;
 

    private CinemachineFreeLook _cmFreeLook;

    // Start is called before the first frame update
    void Start()
    {
        _cmFreeLook = GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        touchScreenCameraMove();
    }

    private void touchScreenCameraMove()
    {
        if (Input.touchCount > 0 && Input.touchCount < 3)
        {
            int rightTouchInd = -1;
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).position.x > 1500)
                    rightTouchInd = i;
            }

            if (rightTouchInd >= 0)
            {
                if (Input.GetTouch(rightTouchInd).phase == TouchPhase.Began)
                {
                    touchPoint1 = Input.GetTouch(rightTouchInd).position;
                }

                if (Input.GetTouch(rightTouchInd).phase == TouchPhase.Moved)
                {
                    touchMove.x = Input.GetTouch(rightTouchInd).deltaPosition.x;
                    touchMove.y = Input.GetTouch(rightTouchInd).deltaPosition.y * Time.deltaTime * -1.0f;
                    _cmFreeLook.m_XAxis.Value += touchMove.x;
                    _cmFreeLook.m_YAxis.Value += touchMove.y;
                }
            }

        }
    }
}
