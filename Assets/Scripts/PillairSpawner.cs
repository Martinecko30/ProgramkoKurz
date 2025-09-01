using System;
using System.Collections.Generic;
using UnityEngine;

public class PillairSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pillair;
    [SerializeField] private Vector3 offset;
    private List<GameObject> pillairs = new List<GameObject>();

    private void Start()
    {
        SpawnPillair(Vector3.zero);
    }

    public void SpawnPillair(Vector3 position)
    {
        if (pillairs.Count >= 2)
        {
            var leftPillair = pillairs[0];
            Destroy(leftPillair);
            pillairs.RemoveAt(0);
        }
        
        var newPillair = Instantiate(pillair, position + offset, Quaternion.identity);
        pillairs.Add(newPillair);
    }
}
