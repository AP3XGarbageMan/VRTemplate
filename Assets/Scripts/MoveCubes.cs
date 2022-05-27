using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubes : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * 6;
    }
}
