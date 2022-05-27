using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberDetect : MonoBehaviour
{
    [SerializeField]
    private LayerMask layer;

    private Vector3 previousPosition;


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1 , layer))
        {
            if (Vector3.Angle(transform.position-previousPosition, hit.transform.up) > 130)
            {
                Destroy(hit.transform.gameObject);
            }
        }
        hit.transform.gameObject.GetComponent<AudioSource>().Play();

        previousPosition = transform.position;
    }
}
