using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Progress;

public class SpellManager : MonoBehaviour
{

    private static Dictionary<string, int> spells = new Dictionary<string, int>();
    private static Dictionary<int, string> spellIndexer = new Dictionary<int, string>();
    public int spellIndex = 1;
    public int CooldownSwitch = 3;
    public bool spellSwitchOnCooldown = false;

    public static void CreateSpell(string spellName, int damage, int spellIndex)
    {
        spells[spellName] = damage;
        spellIndexer[spellIndex] = spellName;
    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(CooldownSwitch);
    }

    private void Start()
    {
        CreateSpell("Psychic", 50, 1);
        CreateSpell("Fire", 35, 2);
        CreateSpell("Water", 20, 3);
    }

    void Update()
    {

        void CooldownForSwitchingSpells() 
        {
            spellSwitchOnCooldown = true;

        }

        if (!spellSwitchOnCooldown)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CooldownForSwitchingSpells();
                spellIndex -= 1;
                if (spellIndex < 1)
                {
                    spellIndex = spells.Count;
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                spellSwitchOnCooldown = true;
                spellIndex += 1;
                if (spellIndex > spells.Count)
                {
                    spellIndex = 1;
                }
            }
        }
        Console.WriteLine(spells[spellIndexer[spellIndex]]);
    }
}
