using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackCooldownScript : MonoBehaviour
{

    public float Cooldown = 1;
    public bool CooldownActive = false;
    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(Cooldown);
        CooldownActive = false;
        print("hey hey hey the cooldown has ended");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !CooldownActive)
        {
            CooldownActive = true;
            print("hey hey hey the cooldown has been activated");
            StartCoroutine(StartCooldown());
        }
    }
}
