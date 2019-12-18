using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Move", menuName = "Move")]
public class SMove : ScriptableObject
{
    public int regenHealth;
    public int regenStamina;
    public int dmgDealt;
    public int staminaUsed;
    public string hand;
    public string height;
    public string name;
    public int hatSpace;
    public int score;
}
