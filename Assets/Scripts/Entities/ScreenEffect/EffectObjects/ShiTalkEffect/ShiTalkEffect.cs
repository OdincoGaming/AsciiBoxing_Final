using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShiTalkEffect : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textTMP;
    [SerializeField]
    private string show;
    [SerializeField]
    private bool isSet;
    
    [SerializeField]
    private string myMove;
    [SerializeField]
    private string myStance;
    [SerializeField]
    private int myHP;
    [SerializeField]
    private int myStamina;
    [SerializeField]
    private string theirMove;
    [SerializeField]
    private string theirStance;
    [SerializeField]
    private int theirHP; 
    [SerializeField]
    private int theirStamina;

    void Start()
    {
        show = "Lets go!";
    }

    void Update()
    {
        isSet = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Player>().screenEffect.isSet;
        if(!isSet)
        {
            myMove = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Player>().screenEffect.myMove;
            myStance = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Player>().screenEffect.myStance;
            myHP = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Player>().screenEffect.myHP;
            myStamina = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Player>().screenEffect.myStamina;

            theirMove = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Player>().screenEffect.theirMove;
            theirStance = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Player>().screenEffect.theirStance;
            theirHP = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Player>().screenEffect.theirHP;
            theirStamina = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Player>().screenEffect.theirStamina;

            if(theirMove.Contains("_hit"))
            {
                show = "Gotcha!";
            }
            else
            {
                show = "whatever";
            }
            gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Player>().screenEffect.isSet = true;
            Debug.Log("Effect");
        }
        textTMP.SetText(show);
    }
}
