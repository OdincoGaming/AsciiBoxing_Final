using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymCard : MonoBehaviour
{
    [SerializeField]
    private string id;
    [SerializeField]
    private int wins;
    [SerializeField]
    private int losses;
    [SerializeField]
    private int cash;
    [SerializeField]
    private SEffect effect;

    public void AddWins()
    {
        wins++;
    }
    
    public void AddLoses()
    {
        losses++;
    }
    
    public void SetID(string id)
    {
        this.id = id;
    }

    public void AddCash(int score)
    {
        this.cash += score;
    }
    
    public void SetEffect(SEffect effect)
    {
        this.effect = effect;
    }
    
    public int GetWins()
    {
        return this.wins;
    }
    
    public int GetLosses()
    {
        return this.losses;
    }

    public string GetID()
    {
        return this.id;
    }

    public int GetCash()
    {
        return this.cash;
    }

    public SEffect GetEffect()
    {
        return this.effect;
    }
}
