using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMoveTest : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        // Debug.Log(scroll * 50000*Time.deltaTime);
        //transform.Rotate(0, scroll * 50000 * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }
}
