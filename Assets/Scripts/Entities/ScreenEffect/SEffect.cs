using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Screen Effect", menuName = "Screen Effect")]
public class SEffect : ScriptableObject
{
    public GameObject effect;
     public bool isSet;
    public string myMove;
    public string myStance;    
    public int myHP;
    public int myStamina;
    public string theirMove;
    public string theirStance;
    public int theirHP; 
    public int theirStamina;
    public void Outcome(string myMove, string myStance, int myHP, int myStamina, string theirMove, string theirStance, int theirHP, int theirStamina)
    {
        this.myMove = myMove;
        this.myStance = myStance;
        this.myHP = myHP;
        this.myStamina = myStamina;

        this.theirMove = theirMove;
        this.theirStance = theirStance;
        this.theirHP = theirHP;
        this.theirStamina = theirStamina;

        isSet = false;
    }

    void Start()
    {
        isSet = true;
    }
}
