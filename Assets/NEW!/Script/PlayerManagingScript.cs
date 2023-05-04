using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagingScript : MonoBehaviour
{
    [SerializeField] private Shooting shootingScript;


    private void Start()
    {
        shootingScript.enabled = false;
        Invoke("UnfreezePlayerController", 14f);
    }

    public void UnfreezePlayerController()
    {
        shootingScript.enabled = true;
    }
}
