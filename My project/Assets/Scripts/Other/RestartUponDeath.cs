using EasyPeasyFirstPersonController;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartUponDeath : MonoBehaviour
{

    public GameObject checkpointsFolder;
    public GameObject elementalObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           // foreach (Transform child in elementalObjects.GetComponentsInChildren<Transform>())
            //{
           //     child.gameObject.SetActive(true);
           // }
           // other.gameObject.transform.position = checkpointsFolder.transform.Find(other.gameObject.GetComponent<FirstPersonController>().checkpoint.ToString()).transform.position;
        }
    }
}
