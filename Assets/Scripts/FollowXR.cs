using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowXR : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerGO;

    private bool shouldFollow = true;

    private void Update()
    {
        if (shouldFollow)
        {
            this.gameObject.transform.rotation.SetLookRotation(PlayerGO.transform.position);
        }
    }
}
