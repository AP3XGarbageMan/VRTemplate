using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectProtonInAssembly : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hatom")
        {
            other.gameObject.transform.parent = transform;
            
        }
    }
}
