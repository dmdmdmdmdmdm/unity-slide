using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 startOffset;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    private Vector3 offset;
    private Vector3 offsetOrbit;
    void Start()
    {
        offset = startOffset;
    }

    // Update is called once per frame
    void LateUpdate()
    {


       transform.position = target.position + target.forward * offset.z + target.right * offset.x + target.up * offset.y;
       


          var targetRotation = Quaternion.LookRotation(target.position + offset.y * target.up - transform.position);

           // Smoothly rotate towards the target point.
          transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }

}
