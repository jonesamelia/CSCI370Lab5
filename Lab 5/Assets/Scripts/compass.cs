using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compass : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTransform;

    Vector3 dir;

    private void update()
    {

        dir.z = playerTransform.eulerAngles.y;
        transform.localEulerAngles = dir;



    }



}
