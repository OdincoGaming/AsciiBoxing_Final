using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the referee makes sure all moves are calculated and applied properly
public class Referee
{
    Player p1;
    Player p2;

    public int[,] Fight(int player, Player p1, Player p2)
    {
        this.p1 = p1;
        this.p2 = p2;
        Player[] p = new Player[2]{p1,p2};

        int[] ph = new int[2] { 0, 0 };
        int[] ps = new int[2] { 0, 0 };
        int fir;
        int sec;
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
        

        if (parry())
        {
            
            ph[fir] = 1;
            ph[sec] = 1;
            ph[sec] -= p[fir].GetMove().dmgDealt;

            ps[fir] = -p[fir].GetMove().staminaUsed;
            ps[sec] = -p[sec].GetMove().staminaUsed;

            p[fir].ResetCombo();
            p[sec].ResetCombo();
        }
        else
        {
            if (attack(p[fir]))
            {
                ph[sec] -= (p[fir].GetMove().dmgDealt + p[fir].GetCombo());
                p[fir].AddCombo();
                if(p[fir].GetCombo() > 3)
                {
                    p[fir].ResetCombo();
                }
                p[sec].ResetCombo();

                ph[sec] += p[sec].GetMove().regenHealth;
                ps[fir] = -p[fir].GetMove().staminaUsed;
                ps[sec] = -p[sec].GetMove().staminaUsed;
            }
            else if(p[fir].GetMove().name == "dodge" && attack(p[sec]))
            {
                ph[fir] = p[fir].GetMove().regenHealth;
                ps[fir] = p[fir].GetMove().regenStamina;

                p[sec].ResetCombo();

                ps[fir] -= p[fir].GetMove().staminaUsed;
                ps[sec] = -p[sec].GetMove().staminaUsed;
            }
            else if(attack(p[sec]))
            {
                ph[fir] = p[fir].GetMove().regenHealth - p[sec].GetCombo();
                ps[fir] = p[fir].GetMove().regenStamina;

                if(p[sec].GetCombo() > 3)
                {
                    p[sec].ResetCombo();
                }
                p[fir].ResetCombo();

                ps[fir] -= p[fir].GetMove().staminaUsed;
                ps[sec] = -p[sec].GetMove().staminaUsed;
            }
            else
            {
                ph[fir] = p[fir].GetMove().regenHealth;
                ps[fir] = p[fir].GetMove().regenStamina;

                p[sec].ResetCombo();
                p[fir].ResetCombo();

                ps[fir] -= p[fir].GetMove().staminaUsed;
                ps[sec] = -p[sec].GetMove().staminaUsed;
            }
        }

        return new int[2, 2] { { ph[0], ps[0] }, { ph[1], ps[1] } };
    }

    private bool parry()
    {
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
