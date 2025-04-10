using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJoshua : MonoBehaviour
{
    public gameObject target;

    [serializeField] private Vector3 posOffset;
    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    if (target != null)
    {
        vector3 newPos = target.transform.position + posOffset;
        transform.position = newPos;
    }

    }

}
