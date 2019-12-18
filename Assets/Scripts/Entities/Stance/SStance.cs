using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stance", menuName = "Stance")]
public class SStance : ScriptableObject
{
    public int dmgDealt;
    public int regenHealth;
    public int regenStamina;
    public string name;
    public int hatSpace;
}
