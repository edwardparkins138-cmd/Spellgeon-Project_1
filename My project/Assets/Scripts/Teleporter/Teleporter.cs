using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class Teleporter : MonoBehaviour
{
    public GameObject TeleporterBlock1;
    public GameObject TeleporterBlock2;

    private void OnCollisionEnter(Collision collision)
    {
        print("ok");
        if (collision.gameObject == TeleporterBlock1)
        {
            print(":tp all me");
            this.transform.position = TeleporterBlock2.transform.position;
        }
    }
}
