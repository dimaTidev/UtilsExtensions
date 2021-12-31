using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ExtensionQuaternion : MonoBehaviour
{
    Transform origin;
    Transform target;

   public Vector3
        rot_origin,
        rot_target,
        rot_delta;

    //Quaternion cprrectrotation

    // Start is called before the first frame update
    void Start()
    {
        origin = new GameObject("Quaternion_origin").transform;
        target = new GameObject("Quaternion_target").transform;
    }

    // Update is called once per frame
    void Update()
    {
        rot_origin = origin.transform.rotation.eulerAngles;
        rot_target = target.transform.rotation.eulerAngles;

        rot_delta = origin.transform.rotation.Delta(target.transform.rotation).eulerAngles;
    }
}
