using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddingForce(Vector3 Target)
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        
        rb.AddForce(Target, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            Invoke("AfterTime", 0.5f);
        }
    }

    public void AfterTime()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        rb.transform.position = new Vector3(0, 1, 0);
    }
}
