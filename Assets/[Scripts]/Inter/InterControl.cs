using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterControl : MonoBehaviour
{

    public enum controlAction
    {
        selfRotation,
        freeFall
    }
    public controlAction controlAct;
    public float universalSpeed = 10.0f;
    public GameObject _player;

    // act rotation
    public Vector3 rotationAxis;
    private float rotAngle = 0;

    // act free fall
    public GameObject checkPoint;
    

    
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
                actRotation(rotationAxis);
                break;
            case controlAction.freeFall:
                actFreeFall();
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
}
