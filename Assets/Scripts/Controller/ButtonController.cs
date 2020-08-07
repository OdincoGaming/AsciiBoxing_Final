using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private FightController fCon;
    [SerializeField]
    private GameObject moveButtons;
    [SerializeField]
    private GameObject stanceButtons;
    [SerializeField]
    private Text showCombo;
    [SerializeField]
    private Text showScore;
    

    public void DeactivateButtons()
    {
        moveButtons.SetActive(false);
        stanceButtons.SetActive(false);
    }

    public void SetMove()
    {
        moveButtons.SetActive(false);
        stanceButtons.SetActive(true);
    }

    public void SetStance()
    {
        stanceButtons.SetActive(false);
    }

    //Reset all buttons on turn start
    public void Reset()
    {
        moveButtons.SetActive(true);
        stanceButtons.SetActive(false);
        if(this.player.GetCombo() < 1)
        {
            this.showCombo.text = "";
        }
        else
        {
            this.showCombo.text = "x"+this.player.GetCombo().ToString();
        }
        this.showScore.text = this.player.GetScore().ToString();
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public void BlockMove()
    {
        this.fCon.PlayerInput(this.player, "block");

        this.SetMove();
    }

    public void LeftPunchMove()
    {
        if(this.player.CurStance() == "block")
        {
            this.fCon.PlayerInput(this.player, "left_uppercut");
        }
        else if(this.player.CurStance() == "attack")
        {
                this.fCon.PlayerInput(this.player, "left_punch");
        }
        else if(this.player.CurStance() == "dodge")
        {
            this.fCon.PlayerInput(this.player, "left_lunge");
        }
        else
        {
            this.fCon.PlayerInput(this.player, "left_punch");
        }

        if(player.GetMove().staminaUsed > player.GetStamina())
            this.fCon.PlayerInput(this.player, "idle");

        this.SetMove();
    }

    public void RightPunchMove()
    {
        if(this.player.CurStance() == "block")
        {
            this.fCon.PlayerInput(this.player, "right_uppercut");
        }
        else if(this.player.CurStance() == "attack")
        {
                this.fCon.PlayerInput(this.player, "right_punch");
        }
        else if(this.player.CurStance() == "dodge")
        {
            this.fCon.PlayerInput(this.player, "right_lunge");
        }
        else
        {
            this.fCon.PlayerInput(this.player, "right_punch");
        }

        if(player.GetMove().staminaUsed > player.GetStamina())
            this.fCon.PlayerInput(this.player, "idle");

        this.SetMove();
    }

    public void DodgeMove()
    {
        this.fCon.PlayerInput(this.player, "dodge");

        this.SetMove();
    }

    public void BlockStance()
    {
        this.fCon.PlayerInput(this.player, "block");

        this.SetStance();
    }

    public void IdleStance()
    {
        this.fCon.PlayerInput(this.player, "idle");

        this.SetStance();
    }

    public void AttackStance()
    {
        this.fCon.PlayerInput(this.player, "attack");

        this.SetStance();
    }

    public void DodgeStance()
    {
        this.fCon.PlayerInput(this.player, "dodge");

        this.SetStance();
    }
}
