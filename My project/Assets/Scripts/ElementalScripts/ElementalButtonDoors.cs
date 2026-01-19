using UnityEngine;

public class ElementalButtonDoors : MonoBehaviour
{

    public void DestroyParentObject()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
