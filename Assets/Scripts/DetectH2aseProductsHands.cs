using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectH2aseProductsHands : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI badAtoms;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hatom" || other.tag == "electron")
        {
            other.gameObject.GetComponent<MoveCubes>().enabled = false;
            other.gameObject.transform.parent = transform;          
        }

        if (other.tag == "Catom" || other.tag == "Natom" || other.tag == "Oatom")
        {
            Destroy(other.gameObject);
            int currentScore = int.Parse(badAtoms.text);
            currentScore++;
            badAtoms.text = currentScore.ToString();
        }

    }
}
