using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField]
    private GymCard card;
    [SerializeField]
    private PlayerController pCon;

    void Start()
    {
        Debug.Log("game started");
        this.pCon.SetPlayer(this.card);
    }

    //second player joins
    public void NewPlayer(GymCard card)
    {
        this.pCon.SetPlayer(card);
    }
}
