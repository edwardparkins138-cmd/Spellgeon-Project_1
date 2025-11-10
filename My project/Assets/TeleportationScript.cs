using UnityEngine;

public class TeleportationScript : MonoBehaviour
{
    public GameObject TeleporterBlock_1;
    public GameObject TeleporterBlock_2;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == TeleporterBlock_1)
        {
            this.gameObject.transform.position = TeleporterBlock_2.transform.position;
        }
        else if (collision.gameObject == TeleporterBlock_2)
        {
            this.gameObject.transform.position = TeleporterBlock_1.transform.position;
        }
    }
}
