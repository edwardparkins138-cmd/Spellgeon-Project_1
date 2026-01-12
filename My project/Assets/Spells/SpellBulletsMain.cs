using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    private float lifetime = 3;

    void Awake()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == gameObject.name + "_ElementWall") 
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
