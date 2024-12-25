using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameHeartScript.health += 1;
    }
}
