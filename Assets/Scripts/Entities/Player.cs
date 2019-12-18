using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GymCard card;
    [SerializeField]
    private int health;
    [SerializeField]
    private int stamina;
    [SerializeField]
    private int score;
    [SerializeField]
    private int combo;
    [SerializeField]
    private bool isSet;
    [SerializeField]
    private BoxerDictionary animations;
    [SerializeField]
    private string animation;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private MoveDictionary moves;
    [SerializeField]
    private StanceDictionary stances;
    [SerializeField]
    private string curStance;
    [SerializeField]
    private string nextStance;
    [SerializeField]
    private SMove move;
    [SerializeField]
    private SStance stance;
    public SEffect screenEffect;
    public GameObject effectCenter;

    void Start()
    {
        nextStance = "idle";
        health = 10;
        stamina = 10;
        score = 0;
        combo = 0;
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void WonGame()
    {
        this.card.AddCash(this.score);
        this.card.AddWins();
    }

    public void LostGame()
    {
        this.score /= 2;
        this.card.AddCash(this.score);
        this.card.AddLoses();
    }

    public void ApplyStance()
    {
        this.curStance = this.nextStance;
        this.stance = this.stances.GetStance(this.curStance);
        
        this.AddHealth(this.stance.regenHealth);
        this.AddStamina(this.stance.regenStamina);

        this.SetAnimation(curStance);

        this.isSet = false;
    }

    public void AddHealth(int hp)
    {
        this.health += hp;
        if (health > 10)
            health = 10;
        if (health < 0)
            health = 0;
    }

    public void AddStamina(int sp)
    {
        this.stamina += sp;
        if (stamina > 10)
            stamina = 10;
        if (stamina < 0)
            stamina = 0;
    }

    public void SetAnimation(string animation)
    {
        this.animation = animation;
        text.text = this.animations.GetAnimation(animation);
    }

    public string GetAnimation()
    {
        return this.animation;
    }
    
    public void SetCard(GymCard card)
    {
        this.card = card;
    }

    public void SetMove(string move)
    {
        this.move = moves.GetMove(move);
    }

    public void SetCurStance()
    {
        curStance = nextStance;
    }

    public void SetStance(string stance)
    {
        this.nextStance = stance;
    }

    public bool HasCard()
    {
        if(this.card == null)
        {
            return false;
        }
        return true;
    }

    public string CurStance()
    {
        return this.curStance;
    }

    public int GetHealth()
    {
        return this.health;
    }

    public int GetStamina()
    {
        return this.stamina;
    }

    public SMove GetMove()
    {
        return this.move;
    }

    public SStance GetStance()
    {
        return this.stance;
    }

    public void AddCombo()
    {
        this.combo++;
    }

    public void ResetCombo()
    {
        this.combo = 0;
    }

    public int GetCombo()
    {
        return this.combo;
    }

    public void AddScore(int score)
    {
        this.score += score;
        if(this.score < 0)
        {
            this.score = 0;
        }
    }

    public int GetScore()
    {
        return this.score;
    }

    public void Set()
    {
        this.isSet = true;
    }
    public bool IsSet()
    {
        return this.isSet;
    }

    public SEffect GetEffect()
    {
        return this.screenEffect;
    }

    public void SetEffect(SEffect screenEffect)
    {
        this.screenEffect = screenEffect;
        GameObject childObject = Instantiate( this.screenEffect.effect) as GameObject;
        childObject.transform.parent = this.effectCenter.transform;
        childObject.transform.localPosition = new Vector3(0,0,0);
    }
}
