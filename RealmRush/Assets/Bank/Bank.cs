using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    [Tooltip("Başlangıç ​​parası")]
    [SerializeField] int startingBalance = 150;

    [Tooltip("//cari(mevcut) Bakiye")]
    [SerializeField] int currentBalance; 
    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] TextMeshProUGUI displayBalance;
    public GameObject RestartPanel;


    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }
   public void Deposit(int amount)
    {     
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }
    public void Withdraw(int amount)
    {  
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        if (currentBalance<0)
        {
            //lose the game;
            ReloadScene();
        }
    }
    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }

    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    void RestartButton() { }
}
