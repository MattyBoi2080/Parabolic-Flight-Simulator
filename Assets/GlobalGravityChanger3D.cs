using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGravityChanger3D : MonoBehaviour
{
    public Vector3 newGravity = new Vector3(0, -1f, 0);
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = newGravity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
