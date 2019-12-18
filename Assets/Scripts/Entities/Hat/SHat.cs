using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hat", menuName = "Hat")]
public class SHat : ScriptableObject
{
    public string name;
    public string hatSpace1;
    public string hatSpace2;
    public string hatSpace3;
    public string toSscreen;
    public string normal;
    public string parry;
    public string parried;
    public string punchHit;
    public string punchBlocked;
    public string punchMiss;
    public string getHit;
    
    public void SetPos(int pos)
    {
        if(pos == 1)
        {
            toSscreen = hatSpace1 + toSscreen;
        }
        else if(pos == 2)
        {
            toSscreen = hatSpace2 + toSscreen;
        }
        else
        {
            toSscreen = hatSpace3 + toSscreen;
        }
    }
}
