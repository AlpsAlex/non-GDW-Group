using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterControl : MonoBehaviour
{

    public enum controlAction
    {
        selfRotation,
        freeFall,
        magicBean
    }
    public controlAction controlAct;
    public float universalSpeed = 10.0f;
    public GameObject _player;

    // act rotation
    public Vector3 rotationAxis;
    private float rotAngle = 0;

    // act free fall
    public GameObject checkPoint;

    // act magic bean
    private bool isMagicBean;
    private float countDown;
    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        switch (controlAct)
        {
            case controlAction.selfRotation:
                isMagicBean = false;
                actRotation(rotationAxis);
                break;
            case controlAction.freeFall:
                isMagicBean = false;
                actFreeFall();
                break;

            case controlAction.magicBean:
                isMagicBean = true;
                actMagicBean(rotationAxis);
                break;

            default:
                break;
        }
    }

    private void actRotation(Vector3 axis)
    {
        rotAngle += (rotAngle < 360) ? 0.5f * universalSpeed : -359.0f;
        transform.rotation = Quaternion.Euler(axis * rotAngle);
    }

    private void actFreeFall()
    {
        if(Vector3.Distance(_player.transform.position, checkPoint.transform.position) <= 2.0f)
        {
            GetComponent<Rigidbody>().useGravity = true;
        }

        if (this.transform.position.y <= -150f) 
            this.gameObject.SetActive(false);
    }

    private void actMagicBean(Vector3 axis)
    {
        rotAngle += (rotAngle < 360) ? 0.5f * universalSpeed : -359.0f;
        transform.rotation = Quaternion.Euler(axis * rotAngle);
        countingDown();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isMagicBean)
        {
            if(collision.transform == _player.transform)
            {
                if(countDown <= 0)
                {
                    if (_player.transform.parent.GetComponent<BasicMovement>().isSmall)
                    {
                        Debug.Log("BIG");
                        countDown = 3;
                        Vector3 lastPos = _player.transform.position;
                        _player.transform.parent.localScale = new Vector3(1f, 1f, 1f);
                        _player.transform.parent.GetComponent<BasicMovement>().isSmall = false;
                        _player.transform.position = lastPos;
                    }
                    else
                    {
                        Debug.Log("Small");
                        countDown = 3;
                        Vector3 lastPos = _player.transform.position;
                        _player.transform.parent.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                        _player.transform.parent.GetComponent<BasicMovement>().isSmall = true;
                        _player.transform.position = lastPos;
                    }
                }
            }
        }
    }

    private void countingDown()
    {
        if(countDown > 0)
        {
            countDown -= Time.deltaTime;
        }
        Debug.Log(countDown);
    }
}
