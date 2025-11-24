using UnityEngine;

public class TeleportationScript : MonoBehaviour
{
    public GameObject TeleporterBlock_1;
    public GameObject TeleporterBlock_2;
    public GameObject Player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == TeleporterBlock_1)
        {
            Player.transform.position = TeleporterBlock_2.transform.position;
        }
        else if (collision.gameObject == TeleporterBlock_2)
        {
            Player.transform.position = TeleporterBlock_1.transform.position;
        }
    }
}
