using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem
{
    Player p1;
    Player p2;

    public void Score(int player, Player p1, Player p2)
    {
        this.p1 = p1;
        this.p2 = p2;
        Player[] p = new Player[2]{p1,p2};
        int[] score = new int[2] {0,0};

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
        
        if(p[fir].IsSet())
            score[fir] += 10;
        if(p[sec].IsSet())
            score[sec] += 10;

        if (parry())
        {
            score[fir] += p[fir].GetMove().score;
        }
        else
        {
            if (attack(p[fir]))
            {
                score[fir] += p[fir].GetMove().score + 5;
                score[sec] += p[sec].GetMove().score;
            }
            else if(p[fir].GetMove().name == "dodge" && attack(p[sec]))
            {
                score[fir] += p[fir].GetMove().score + 5;
                score[sec] += (p[sec].GetMove().score - 5);
            }
            else if(attack(p[sec]))
            {
                score[fir] += p[fir].GetMove().score + 5;
                score[sec] += p[sec].GetMove().score;
            }
            else
            {
                score[fir] += p[fir].GetMove().score;
                score[sec] += p[sec].GetMove().score;
            }
        }

        p[fir].AddScore(score[fir]);
        p[fir].AddScore(score[fir]);
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
