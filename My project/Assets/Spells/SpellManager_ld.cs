using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Progress;

public class SpellManager : MonoBehaviour
{

    private static Dictionary<int, string> spells = new Dictionary<int, string>();
    public int spellIndex = 1;
    public bool spellSwitchOnCooldown = false;

    public float Cooldown = 1;
    public bool CooldownActive = false;
    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(Cooldown);
        CooldownActive = false;
    }

    public static void CreateSpell(string spellName, int spellIndex)
    {
        spells[spellIndex] = spellName;
    }

    void Start()
    {
        Debug.Log("Hello");
        // Value 1 | Name - Value 2 | Index
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
                spellIndex = spells.Count;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            spellIndex += 1;
            if (spellIndex > spells.Count)
            {
                spellIndex = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && !CooldownActive)
        {
            CooldownActive = true;
            StartCoroutine(StartCooldown());
        }
        Debug.Log(spells[spellIndex]);
    }
}
