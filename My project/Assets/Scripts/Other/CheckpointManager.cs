using EasyPeasyFirstPersonController;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            other.gameObject.GetComponent<FirstPersonController>().checkpoint = int.Parse(gameObject.name);
        }
    }
}