using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [Tooltip("Alt�n cezas�")]
    [SerializeField] int goldPenalty = 25;

    Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }
    public void RewardGold() //alt�n �d�l
    {
        if (bank == null) { return; } //BU SCR�PT varm� yok mu null ile �ek ederiz.
        {
            bank.Deposit(goldReward);
        }
    }
    public void StealGold() //Alt�n �almak
    {
        if (bank == null) { return; }
        {
            bank.Withdraw(goldPenalty);
        }
    }
}
