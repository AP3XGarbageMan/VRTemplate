using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectElectronInAssembly : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "electron")
        {
            other.gameObject.transform.parent = transform;          
        }
    }

}
