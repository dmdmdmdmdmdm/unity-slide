using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public float turnspeed = 2f;
    public float rotSpeed = 2f;
    private Rigidbody rb;
    private Collider oldColl;
    public float jumpPower = 1000f;
    
    public float rotSpeedActual = 0;
    [SerializeField]
    private float jumpDelay = 0.5f;
    private float jumpTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        
        
        rb.velocity += rb.transform.right * turnspeed * hor * Time.fixedDeltaTime;

        //transform.position += transform.right * turnspeed * hor * Time.fixedDeltaTime;

        if (Input.GetKey(KeyCode.Space) && jumpTimer > jumpDelay)
        {
            rb.AddForce(rb.transform.up * jumpPower * rb.mass);
            jumpTimer = 0;
        }
        if(jumpTimer < jumpDelay * 2)
        {
            jumpTimer += Time.fixedDeltaTime;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Forcer"))
        {

          rb.velocity += collision.transform.forward * speed * 1 * Time.fixedDeltaTime;
            //float rotAmount = transform.rotation.y - collision.transform.rotation.y;


            Vector3 axis;
            float angle;
            GetShortestAngleAxisBetween(transform.rotation, collision.transform.rotation, out axis, out angle);
            
            float duration = 1;
           // Debug.Log(angle);
            if(angle > 180 && angle < 360)
            {
                angle -= 360;
            }
            if (angle < -180 && angle > -360)
            {
                angle += 360;
            }
            rotSpeedActual = angle;
            //again we get the longAngle with all the extra spins
            float longAngle = angle;
            float anglePerSecond = longAngle / duration;
            float magn = rb.velocity.magnitude;
            transform.rotation *= Quaternion.AngleAxis(anglePerSecond *  Time.deltaTime, axis);


        }
    }


    public static void GetShortestAngleAxisBetween(Quaternion a, Quaternion b, out Vector3 axis, out float angle)
    {
        var dq = Quaternion.Inverse(a) * b;
        if (dq.w > 1) dq = Normalize(dq);

        //get as doubles for precision
        var qw = (double)dq.w;
        var qx = (double)dq.x;
        var qy = (double)dq.y;
        var qz = (double)dq.z;
        var ratio = System.Math.Sqrt(1.0d - qw * qw);

        angle = (float)(2.0d * System.Math.Acos(qw)) * Mathf.Rad2Deg;
        if (ratio < 0.001d)
        {
            axis = new Vector3(1f, 0f, 0f);
        }
        else
        {
            axis = new Vector3(
                (float)(qx / ratio),
                (float)(qy / ratio),
                (float)(qz / ratio));
            axis.Normalize();
        }
    }

    public static Quaternion Normalize(Quaternion q)
    {
        var mag = System.Math.Sqrt(q.w * q.w + q.x * q.x + q.y * q.y + q.z * q.z);
        q.w = (float)((double)q.w / mag);
        q.x = (float)((double)q.x / mag);
        q.y = (float)((double)q.y / mag);
        q.z = (float)((double)q.z / mag);
        return q;
    }
}
