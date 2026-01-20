using EasyPeasyFirstPersonController;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartUponDeath : MonoBehaviour
{

    public GameObject checkpointsFolder;
    public Transform elementalObjects;
    public List<Transform> allIstances;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GetDescendants(elementalObjects);

            for (int index = 0; index < allIstances.Count; index++)
            {
                allIstances[index].gameObject.SetActive(true);
            }

            other.gameObject.transform.position = checkpointsFolder.transform.Find(other.gameObject.GetComponent<FirstPersonController>().checkpoint.ToString()).transform.position;
        }
    }

    // Roblox reference.
    void GetDescendants(Transform objTransform) 
    {
        allIstances.Add(objTransform);

        int numberOfChildren = objTransform.childCount;

        if (numberOfChildren > 0)
        {
            for (int repeatedAmount = 0; repeatedAmount < numberOfChildren; repeatedAmount++)
            {
                GetDescendants(objTransform.GetChild(repeatedAmount));
            }
        }
    }
}
