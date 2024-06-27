using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStats : MonoBehaviour
{
    [SerializeField]
     Stats[] stats = new Stats [(int)StatsEnum.ArmorType + 1];

    [ContextMenu("Set Stats")]

    /// For each item in the stats list, loop through each one in ascending order.
    void SetStats()
    {
        for(int i = 0; i < stats.Length; i++)
        {
            // convert an int value to an enum. both use ints.
            stats[i].type = (StatsEnum)i;
        }
    }

    [ContextMenu("Set Stats")]
    void Randomize()
    {
        // for each stat, loop through all of them and assign a random number.
        // 
        for(int i = 0; i < stats.Length; i++)
        {
            stats[i].value = Random.Range(0, 100);
        }
    }
}

