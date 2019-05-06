using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBackground : MonoBehaviour
{
    public int max;
    public int min;
    public int dist;
    public float minHeight;
    public float maxHeight;
    public float minWidthX;
    public float minWidthZ;
    public float maxWidthX;
    public float maxWidthZ;
    public GameObject building;
    public float rotation;
    public Material[] materials;
    // Start is called before the first frame update
    void Start()
    {
        
        for (int x = -max; x < max; x = x + dist)
        {
            for (int z = -max; z < max; z = z + dist)
            {
                int absX = Mathf.Abs(x);
                int absZ = Mathf.Abs(z);
                if (absX > min && absX < max)
                {
                    if (absZ > min && absZ < max)
                    {
                        GameObject bld = Instantiate(building, new Vector3(x, 0 , z), Quaternion.identity, this.gameObject.transform);
                        bld.transform.localScale = new Vector3(Random.Range(minWidthX, maxWidthX), Random.Range(minHeight, maxHeight), Random.Range(minWidthX, maxWidthX));
                       // MeshRenderer mr = bld.GetComponent<MeshRenderer>();
                       // mr.material = materials[Random.Range(0, materials.Length - 1)];
                    }
                }

            }
        }
        
        this.gameObject.transform.Rotate(0, rotation, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
