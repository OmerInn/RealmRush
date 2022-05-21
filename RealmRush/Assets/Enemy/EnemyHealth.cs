using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds Amount maxhitpoints when enemy dies.")] //Düþman öldüðünde Amount maksimum can puaný ekler.
    [SerializeField] int diffucultyRamp = 1;
    int currentHitPoints = 0;


    Enemy enemy;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        currentHitPoints--;
        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += diffucultyRamp;
            enemy.RewardGold();
        }
    }
}
