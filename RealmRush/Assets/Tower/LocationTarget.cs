using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTarget : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15;
     Transform target;
    // en yakýn hedef = closestTarget
    private void Update()
    {
        FindClosestTarget();
        AimWeapon();

    }
    void FindClosestTarget() //En Yakin Hedefi Bul 
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>(); //Türün Nesnelerini Bul
        Transform closesTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance<maxDistance)
            {
                closesTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closesTarget;
    }

    void AimWeapon() //nisan silahý
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if (targetDistance<range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }
    void Attack(bool isActive)
    {
        var emmisionModule = projectileParticles.emission;
        emmisionModule.enabled = isActive;
    }
}
