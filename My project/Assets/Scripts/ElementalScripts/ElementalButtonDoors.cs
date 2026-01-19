using UnityEngine;

public class ElementalButtonDoors : MonoBehaviour
{

    public void DestroyParentObject()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
