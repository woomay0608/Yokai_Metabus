using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Target;
    float Offsetx;


    void Start()
    {
        if (Target == null)
            return;

        Offsetx = transform.position.x - Target.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null) return;

        Vector3 pos = transform.position;
        pos.x = Target.position.x + Offsetx;
        transform.position = pos;


    }


}
