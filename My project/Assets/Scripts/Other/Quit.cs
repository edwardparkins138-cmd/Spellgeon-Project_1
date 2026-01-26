using Unity.VisualScripting;
using UnityEngine;

public class Quit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Application.Quit();
        }
    }

}
