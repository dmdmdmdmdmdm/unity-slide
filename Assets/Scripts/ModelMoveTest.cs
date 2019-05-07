using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMoveTest : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerMovement pm;
    private float afterGroundDelay = 1f;
    private float afterGroundTimer = 0f;

    public Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        pm = GetComponentInParent<PlayerMovement>();
        tr = transform;
    }

    // Update is called once per frame
    void Update()
    {
        tr = transform;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rb.velocity), Time.deltaTime * 10);

        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        // Debug.Log(scroll * 50000*Time.deltaTime);
        //transform.Rotate(0, scroll * 50000 * Time.deltaTime, 0);
        //Vector3 velSmooth = rb.velocity;
        //if(Mathf.Abs(velSmooth.x) < 0.2)
        //{
        //    velSmooth.x = 0;
        //}
        //if (Mathf.Abs(velSmooth.y) < 0.2)
        //{
        //    velSmooth.y = 0;
        //}
        //if (Mathf.Abs(velSmooth.z) < 0.2)
        //{
        //    velSmooth.z = 0;
        //}



        //if (pm.isGrounded() && afterGroundTimer > afterGroundDelay)
        //{
        //    Vector3 relativePos = rb.velocity - transform.forward;
        //    Quaternion LookAtRotation = Quaternion.LookRotation(relativePos);

        //    Quaternion LookAtRotationOnly_Y = Quaternion.Euler(transform.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        //    transform.rotation = LookAtRotationOnly_Y;
        //} else 
        //{
        //    transform.rotation = Quaternion.LookRotation(rb.velocity);

        //} 

        //if (pm.isGrounded())
        //{
        //    afterGroundTimer += Time.fixedDeltaTime;
        //} else
        //{
        //    afterGroundTimer = 0;
        //}

    }
   

}

