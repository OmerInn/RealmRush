using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [Tooltip("Balista")]
    [SerializeField] Tower towerPrefab;
    [Tooltip("ArrowTower")]
    [SerializeField] Tower towerArrowPrefab;
    [Tooltip("Yerleþtirilebilir alaný belirler.")]
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

     void OnMouseDown()
    {
       if (isPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }
  
}
