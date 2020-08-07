using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    
    [SerializeField]
    private Player p1;
    [SerializeField]
    private Player p2;

    public void Fight(int player)
    {
        Player[] p = new Player[2]{this.p1, this.p2};

        int fir;
        int sec;
        //Determine who went first
        if(player == 1)
        {
            fir = 0;
            sec = 1;
        }
        else
        {
            fir = 1;
            sec = 0;
        }

        if(parry())
        {
            p[fir].SetAnimation(p[fir].GetMove().name);
            //Add is hit version to [sec]
            p[sec].SetAnimation(p[sec].GetMove().name+"_hit");
        }
        else
        {
            if(attack(p[fir]))
            {
                p[fir].SetAnimation(p[fir].GetMove().name);
                //Add is hit version to [sec]
                p[sec].SetAnimation(p[sec].GetMove().name+"_hit");
            }
            else if(attack(p[sec]))
            {
                p[fir].SetAnimation(p[fir].GetMove().name);
                p[sec].SetAnimation(p[sec].GetMove().name);
            }
            else
            {
                p[fir].SetAnimation(p[fir].GetMove().name);
                p[sec].SetAnimation(p[sec].GetMove().name);
            }
        }
        p[fir].screenEffect.Outcome(p[fir].GetAnimation(), p[fir].GetStance().name, p[fir].GetHealth(), p[fir].GetStamina(), p[sec].GetAnimation(), p[sec].GetStance().name, p[sec].GetHealth(), p[sec].GetStamina());
        p[sec].screenEffect.Outcome(p[sec].GetAnimation(), p[sec].GetStance().name, p[sec].GetHealth(), p[sec].GetStamina(),p[fir].GetAnimation(), p[fir].GetStance().name, p[fir].GetHealth(), p[fir].GetStamina());
    }

     private bool parry()
    {
        //Check to see if a parry occured
        if(p1.GetMove().hand == "right" && p2.GetMove().hand == "left")
        {
            if(p1.GetMove().height == p2.GetMove().height)
            {
                return true;
            }
        }
        else if(p1.GetMove().hand == "left" && p2.GetMove().hand == "right")
        {
            if(p1.GetMove().height == p2.GetMove().height)
            {
                return true;
            }
        }
        return false;
    }

    private bool attack(Player move)
    {
        if(move.GetMove().hand == "left" || move.GetMove().hand == "right")
            return true;

        return false;
    }
}
