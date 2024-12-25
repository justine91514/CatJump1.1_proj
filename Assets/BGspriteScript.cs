using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGspriteScript : MonoBehaviour
{
    private float deadZone = -26.46f;
   
    void Update()
    {
        if (transform.position.y < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
