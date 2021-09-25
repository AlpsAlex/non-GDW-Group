using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    Rigidbody rigidbody;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Debug.Log(Vector3.forward);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float veloX = Input.GetAxis("Horizontal");
        float veloZ = Input.GetAxis("Vertical");
        Vector3 veloInput = new Vector3(veloX, 0, veloZ);
        veloInput = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) * veloInput;

        Debug.Log(rigidbody.transform.position);
        //Debug.Log(veloX);
        //Debug.Log(veloZ);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D)))
        {
            rigidbody.AddForce(veloInput * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Plane")
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.transform.localPosition = new Vector3(-1f, 22f, -30f);
        }
    }
}
