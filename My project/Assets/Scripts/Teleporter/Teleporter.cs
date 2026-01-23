using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleporter : MonoBehaviour
{
    public Transform TeleportTo;
    public GameObject PlayerObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerObject)
        {
            PlayerObject.transform.position = TeleportTo.transform.position;
        }
    }
}