using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectProductsInAssembly : MonoBehaviour
{
    // two hol
    [SerializeField]
    private GameObject[] assemblyHoldersTop;
    [SerializeField]
    private GameObject[] assemblyHoldersBottom;

    [SerializeField]
    private GameObject protonAnimTop;
    [SerializeField]
    private GameObject protonAnimBottom;
    [SerializeField]
    private GameObject protonAnimH2;

    private bool topShown = false;
    private bool bottomShown = false;
    private bool h2Playing = false;

    [SerializeField]
    private TextMeshProUGUI scoreLabel;
    private int scoreTotal = 0;
    //private int lastScore = 0;

    private void Start()
    {
        StartCoroutine(CheckForProductsLoop());
    }

    IEnumerator CheckForProductsLoop()
    {
        while (true)
        {
            if (h2Playing)
            {
                protonAnimH2.SetActive(false);
            }

            //Debug.Log("Checking for products");
            CheckForH2Production();

            CheckForProducts(assemblyHoldersTop, "top");
            CheckForProducts(assemblyHoldersBottom, "bottom");
            
            yield return new WaitForSeconds(1.0f);
        }

    }

    private void CheckForH2Production()
    {
        if (topShown && bottomShown)
        {
            protonAnimTop.SetActive(false);
            protonAnimBottom.SetActive(false);
            protonAnimH2.SetActive(true);
            topShown = false;
            bottomShown = false;
            h2Playing = true;
            scoreTotal++;
        }

        scoreLabel.text = scoreTotal.ToString();
    }

    public void CheckForProducts(GameObject[] _containers, string _pos)
    {
        int totalElectrons = 0;
        int totalProtons = 0;

        foreach (GameObject _holder in _containers)
        {
            switch (_holder.tag)
            {
                case "eHolder":
                    if(_holder.transform.childCount > 0)
                    {
                        totalElectrons = _holder.transform.childCount;
                    }
                    break;
                case "protonHolder":
                    if (_holder.transform.childCount > 0)
                    {
                        totalProtons = _holder.transform.childCount;
                    }
                    break;
                default:
                    Debug.Log("broek");
                    break;
            }

        }

        Debug.Log("total electrons = " + totalElectrons.ToString() + ", total protons = " + totalProtons.ToString());

        if (totalElectrons > 0 && totalProtons > 0)
        {
            foreach (GameObject _holder in _containers)
            {
                Destroy(_holder.gameObject.transform.GetChild(0).gameObject);
            }

            if (_pos == "top")
            {
                protonAnimTop.SetActive(true);
                topShown = true;
            }
            if (_pos == "bottom")
            {
                protonAnimBottom.SetActive(true);
                bottomShown = true;
            }
            
        }
    }

}
