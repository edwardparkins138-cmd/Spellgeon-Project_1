using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class NewMonoBehaviourScript : MonoBehaviour
{

    private float lifetime = 3;
    public bool isPlayerOwned;

    void Awake()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isPlayerOwned)
        {
            if (collision.gameObject.name == gameObject.name + "_ElementWall")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else if (collision.gameObject.name == gameObject.name + "_ElementButton")
            {
                collision.gameObject.GetComponent<ElementalButtonDoors>().DestroyParentObject();
                Destroy(gameObject);
            }
            else if (collision.gameObject.name == "Enemy")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}
