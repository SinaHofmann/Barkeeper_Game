using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    void Update()
    {
        //transform.LookAt(Camera.main.transform.position, Vector3.up);

        Vector3 v = Camera.main.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(Camera.main.transform.position - v);
    }
}
