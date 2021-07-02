using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] float thrusterForce = 1000f;
    [SerializeField] float tiltingForce = 100f;
    bool thrust = false;
    Rigidbody rgdBody;
    // Start is called before the first frame update
    private void Awake()
    {
        rgdBody = GetComponent<Rigidbody>();
    }
 

    // Update is called once per frame
    void Update()
    {
        FlyController();
    }
    void FlyController()
    {
        float tilt = Input.GetAxis("Horizontal");

        thrust = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space);
        if (!Mathf.Approximately(tilt, 0f))
        {
            rgdBody.freezeRotation = true;
            Vector3 rotationVector = new Vector3(0f, 0f, tilt * tiltingForce * Time.deltaTime);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + rotationVector);
        }

        rgdBody.freezeRotation = false;
    }

    private void FixedUpdate()
    {
        if (thrust)
        {
            rgdBody.AddRelativeForce(Vector3.up * thrusterForce * Time.deltaTime);
        }
    }
}
