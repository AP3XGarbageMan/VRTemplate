using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberDetect : MonoBehaviour
{
    [SerializeField]
    private LayerMask goodHitLayer;
    [SerializeField]
    private LayerMask badHitLayer;

    private Vector3 previousPosition;

    private AudioSource audio;

    [SerializeField]
    private AudioClip slashSound;
    [SerializeField]
    private AudioClip bombSound;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1 , goodHitLayer))
        {
            if (Vector3.Angle(transform.position-previousPosition, hit.transform.up) > 130)
            {
                audio.PlayOneShot(slashSound);
                Destroy(hit.transform.gameObject);
            }
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, badHitLayer))
        {
            if (Vector3.Angle(transform.position - previousPosition, hit.transform.up) > 120)
            {
                audio.PlayOneShot(bombSound);
                Destroy(hit.transform.gameObject);
            }
        }

        previousPosition = transform.position;
    }
}
