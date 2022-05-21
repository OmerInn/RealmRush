using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [Tooltip("Altýn cezasý")]
    [SerializeField] int goldPenalty = 25;

    Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }
    public void RewardGold() //altýn ödül
    {
        if (bank == null) { return; } //BU SCRÝPT varmý yok mu null ile çek ederiz.
        {
            bank.Deposit(goldReward);
        }
    }
    public void StealGold() //Altýn çalmak
    {
        if (bank == null) { return; }
        {
            bank.Withdraw(goldPenalty);
        }
    }
}
