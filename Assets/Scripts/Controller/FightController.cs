using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{
    [SerializeField]
    private AnimController animCont;
    private Referee theRef;
    private ScoreSystem scoreSystem;
    public Player p1;
    public Player p2;
    private bool p1Move;
    [SerializeField]
    private bool p1Stance;
    private bool p2Move;
    [SerializeField]
    private bool p2Stance;
    private bool pre;
    private bool mid;
    private bool preSet;
    private bool midSet;
    private bool postSet;
    private bool isOver;
    private int goFirst;
    private string winner;
    [SerializeField]
    private float preRound;
    [SerializeField]
    private float midRound;
    [SerializeField]
    private float postRound;
    [SerializeField]
    private ButtonController buttons;
    
    // Start is called before the first frame update
    void Start()
    {
        pre = false;
        mid = false;
        preSet = false;
        midSet = false;
        postSet = false;
        isOver = false;
        theRef = new Referee();
        scoreSystem = new ScoreSystem();
        p1Move = false;
        p1Stance = false;
        p2Move = false;
        p2Stance = false;
        buttons.DeactivateButtons();
    }

    void FixedUpdate()
    {
        //pre round
        if(!this.pre && !this.isOver)
        {
            //start of pre round
            if(!this.preSet)
            {
                this.PreRound();
                //starts pre round timer
                this.preSet = true;
                this.preRound = 0f;
            }
            else if(this.preRound > 3f || (p1Stance && p2Stance))
            {
                this.pre = true;
                //hide buttons
                buttons.DeactivateButtons();
            }
            else
            {
                this.preRound += Time.deltaTime;
            }
        }
        //mid round
        else if(!this.mid  && !this.isOver)
        {
            //start of mid round
            if(!this.midSet)
            {
                this.MidRound();
                //starts mid round timer
                this.midRound = 0f;
                this.midSet = true;
            }
            else if(this.midRound > .25f)
            {
                this.mid = true;
            }
            else
            {
                this.midRound += Time.deltaTime;
            }
        }
        //post round
        else if(!this.isOver)
        {
            //start of post round
            if(!this.postSet)
            {
                this.PostRound();
                //starts post round timer
                this.postRound = 0f;
                this.postSet = true;
            }
            else if(this.postRound > .25f)
            {
                this.pre = false;
                this.mid = false;
                this.preSet = false;
                this.midSet = false;
                this.postSet = false;
            }
            else
            {
                this.postRound += Time.deltaTime;
            }
        }
        //check for ko
        if(this.ko_d() && !this.isOver)
        {
            //game is over
            this.isOver = true;
            this.Over();
        }
    }

    public void PreRound()
    {
         //apply stances
        p1.ApplyStance();
        p2.ApplyStance();
        if(p1.GetStance().dmgDealt > 0)
            p2.AddHealth(-p1.GetStance().dmgDealt);
        if(p2.GetStance().dmgDealt > 0)
            p1.AddHealth(-p2.GetStance().dmgDealt);
        
        //reset moves
        p1.SetMove("idle");
        p2.SetMove("idle");
        p1.SetStance("idle");
        p2.SetStance("idle");

        //show buttons
        this.buttons.Reset();
    }

    public void MidRound()
    {
        //Check Stances to see if a move was made
        if(!this.p1Stance)
        {
            this.p1.SetMove("idle");
        }
        if(!this.p2Stance)
        {
            this.p2.SetMove("idle");
        }
        this.scoreSystem.Score(this.goFirst, this.p1, this.p2);
        int[,] arr = this.theRef.Fight(this.goFirst, this.p1, this.p2);
        this.animCont.Fight(goFirst);

        //taking stuff from arr and setting player attributes
        this.p1.AddHealth(arr[0, 0]);
        this.p1.AddStamina(arr[0, 1]);
        this.p2.AddHealth(arr[1, 0]);
        this.p2.AddStamina(arr[1, 1]);
    }

    public void PostRound()
    {
        //reset move ip checks
        p1Move = false;
        p1Stance = false;
        p2Move = false;
        p2Stance = false;
    }
    
    public void Over()
    {
        if(winner == "first")
        {
            p1.WonGame();
            p2.LostGame();
        }
        else if(winner == "second")
        {
            p1.LostGame();
            p2.WonGame();
        }
        else
        {

        }
        Debug.Log("GAME IS OVER");
    }

    //check for ko
    private bool ko_d()
    {
        if(p1.GetHealth() < 1 && p2.GetHealth() < 1)
        {
            winner = "draw";
            return true;
        }
        else if(p1.GetHealth() < 1)
        {
            winner = "first";
            return true;
        }
        else if(p2.GetHealth() < 1)
        {
            winner = "second";
            return true;
        }
        return false;
    }

    public void PlayerInput(Player p, string ip)
    {
        
        if(p == p1)
        {
            if(!p1Move)
            {
                p.SetMove(ip);
                p1Move = true;
            }
            else
            {
                p.SetStance(ip);
                p1Stance = true;
                if(!p2Stance)
                    goFirst = 1;

                p1.Set();
            }
        }
        else if(p == p2)
        {
            if(!p2Move)
            {
                p.SetMove(ip);
                p2Move = true;
            }
            else
            {
                p.SetStance(ip);
                p2Stance = true;
                if(!p1Stance)
                    goFirst = 2;

                p2.Set();
            }
        }
    }
}
