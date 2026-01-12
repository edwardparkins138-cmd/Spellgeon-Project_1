using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Progress;

public class SpellManager : MonoBehaviour
{

    private static Dictionary<int, string> spellsName = new Dictionary<int, string>();
    private static Dictionary<int, Color> spellColours = new Dictionary<int, Color>();
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

    private static void CreateSpell(string spellName, int spellIndex, Color colour)
    {
        spellsName.Add(spellIndex, spellName);
        spellColours.Add(spellIndex, colour);
    }

    void Start()
    {
        // Value 1 | Name - Value 2 | Index - Value 3 | Colour
        CreateSpell("Nature", 1, Color.green);
        CreateSpell("Fire", 2, Color.red);
        CreateSpell("Water", 3, Color.blue);
        CreateSpell("Psychic", 4, Color.rebeccaPurple);

    }

    void Update()
    {

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

            var magicBullet = Instantiate(bulletPrefabObj, bulletStartPos.position + transform.forward, bulletStartPos.rotation);
            magicBullet.GetComponent<Rigidbody>().linearVelocity = bulletStartPos.forward * bulletSpeed;
            magicBullet.GetComponent<Renderer>().material.SetColor("_BaseColor", spellColours[spellIndex]);
            magicBullet.name = spellsName[spellIndex];

            StartCoroutine(StartCooldown());
        }
    }
}
