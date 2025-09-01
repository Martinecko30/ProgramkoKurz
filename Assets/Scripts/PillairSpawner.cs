using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
        // Removes the first spawned pillair
        // Max pillairs defines how many it can spawn before deleting first one
        int maxPillairs = 4;
        if (pillairs.Count >= maxPillairs)
        {
            var leftPillair = pillairs[0];
            Destroy(leftPillair);
            pillairs.RemoveAt(0);
        }
        
        // Random offset, moves up and down
        //var randomOffset = new Vector3(0, Random.Range(-0.5f, 0.5f), 0);
        var randomOffset = Vector3.up * Random.Range(-0.5f, 0.5f); // Preferred way
        
        // Instantiates new one and adds it to list
        var newPillair = Instantiate(pillair, position + offset + randomOffset, Quaternion.identity);
        pillairs.Add(newPillair);
    }
}
