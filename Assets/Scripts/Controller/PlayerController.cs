using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Player player1;
    [SerializeField]
    private Player player2;
    [SerializeField]
    private ButtonController bCon;

    public void SetPlayer(GymCard card)
    {
        //Ensure players are loaded properly
        if(!this.player1.HasCard())
        {
            this.player1.SetCard(card);
            this.player1.SetEffect(card.GetEffect());
            this.bCon.SetPlayer(this.player1);
        }
        else if(!this.player2.HasCard())
        {
            this.player2.SetCard(card);
            this.bCon.SetPlayer(this.player2);
        }
    }
}
