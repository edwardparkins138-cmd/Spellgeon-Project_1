using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Progress;

public class SpellManager : MonoBehaviour
{

    private static Dictionary<int, string> spellsName = new Dictionary<int, string>();
    private static Dictionary<int, GameObject> spellColours = new Dictionary<int, GameObject>();
    private int spellIndex = 1;

    private float Cooldown = 1;
    private bool CooldownActive = false;

    public Transform bulletStartPos;
    public GameObject bulletPrefabObj;
    public float bulletSpeed = 15;
    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(Cooldown);
        CooldownActive = false;
    }

    private static void CreateSpell(string spellName, int spellIndex)
    {
        spellsName.Add(spellIndex, spellName);
        //spellColours.Add(spellIndex, colour);
    }

    void Start()
    {
        Debug.Log("Hello");
        // Value 1 | Name - Value 2 | Index - Value 3 | Colour
        CreateSpell("Psychic", 1);
        CreateSpell("Fire", 2);
        CreateSpell("Water", 3);

        Debug.Log("Created spells!");
    }

    void Update()
    {
        Debug.Log("is this running?");

        if (Input.GetKeyDown(KeyCode.Q))
        {
            spellIndex -= 1;
            if (spellIndex < 1)
            {
                spellIndex = spellsName.Count;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            spellIndex += 1;
            if (spellIndex > spellsName.Count)
            {
                spellIndex = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && !CooldownActive)
        {
            CooldownActive = true;

            var bullet = Instantiate(bulletPrefabObj, bulletStartPos.position + transform.forward, bulletStartPos.rotation);
            bullet.GetComponent<Rigidbody>().linearVelocity = bulletStartPos.forward * bulletSpeed;

            StartCoroutine(StartCooldown());
        }
        Debug.Log(spellsName[spellIndex]);
    }
}
