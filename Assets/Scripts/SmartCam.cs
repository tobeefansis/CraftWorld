using UnityEngine;
using System.Collections;

public class SmartCam : MonoBehaviour
{
    public Transform Camera;
    public Transform Target;
    public Vector3 ofset;
    // Use this for initialization
    void Start()
    {
        
    }
    /// <summary>
    /// x0  y0
    /// [   ]
    /// y1  x1
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (Camera && Target)
        {
            Camera.position = Target.position + ofset;
        }
    }
}
