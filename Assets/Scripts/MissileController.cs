using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    [SerializeField] GameObject target;
    private Rigidbody rgB;
    // Start is called before the first frame update
    void Start()
    {
        rgB = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

     
    }

    private void FixedUpdate()
    {

        Vector3 targetDirection = transform.position - target.transform.position;
        Vector3 rotationDirection = Vector3.RotateTowards(transform.localPosition, targetDirection, 360, 0.00f);
        transform.rotation = Quaternion.LookRotation(rotationDirection);

    }
}
