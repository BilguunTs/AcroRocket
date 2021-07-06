using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] float thrusterForce = 1000f;
    [SerializeField] float tiltingForce = 100f;
    bool thrust = false;
    Rigidbody rgdBody;
    float angletoRotate = 60f;
    float speed = 1f;
    Quaternion targetRotation;
    // Start is called before the first frame update
    private void Awake()
    {
        rgdBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        targetRotation = transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        //   FlyController();
        RotateTest();
    }
    void RotateTest()
    {
       
        if (Input.GetKey(KeyCode.Space))
        {
            targetRotation *= Quaternion.AngleAxis(angletoRotate ,Vector3.right);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);
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
