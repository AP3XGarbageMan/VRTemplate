using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaberDetect : MonoBehaviour
{
    [SerializeField]
    private LayerMask goodHitLayer;
    [SerializeField]
    private LayerMask badHitLayer;

    [SerializeField]
    private TMP_Text correctHitText;
    [SerializeField]
    private TMP_Text incorrectHitText;

    private Vector3 previousPosition;

    private AudioSource audio;

    [SerializeField]
    private AudioClip slashSound;
    [SerializeField]
    private AudioClip bombSound;

    private int correctHitInt;
    private int incorrectHitInt;

    private void Start()
    {
        incorrectHitInt = 0;
        correctHitInt = 0;

        incorrectHitText.text = incorrectHitInt.ToString();
        correctHitText.text = correctHitInt.ToString();
        
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
                correctHitInt++;
                correctHitText.text = int.Parse(correctHitText.text) + correctHitInt.ToString();
            }
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, badHitLayer))
        {
            if (Vector3.Angle(transform.position - previousPosition, hit.transform.up) > 120)
            {
                audio.PlayOneShot(bombSound);
                Destroy(hit.transform.gameObject);
                incorrectHitInt++;
                incorrectHitText.text = int.Parse(incorrectHitText.text) + incorrectHitInt.ToString();
            }
        }

        previousPosition = transform.position;
    }
}
