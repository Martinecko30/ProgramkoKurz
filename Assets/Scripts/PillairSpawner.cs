using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PillairSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pillair;
    [SerializeField] private Vector3 offset;
    private List<GameObject> pillairs = new List<GameObject>();

    private void Start()
    {
        SpawnPillair();
        SpawnPillair();
    }

    public Vector3 SpawnPillair()
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
        var lastPillairPos = pillairs.Count > 0 ? pillairs.Last().transform.position : Vector3.zero;
        var newPillair = Instantiate(pillair, lastPillairPos + offset + randomOffset, Quaternion.identity);
        pillairs.Add(newPillair);
        
        return newPillair.transform.position;
    }

    public void ClearAllPillairs()
    {
        // This might be easier to understand for beginners
        /*
        foreach (var pillairObj in pillairs)
        {
            Destroy(pillairObj);
        }
        */
        pillairs.ForEach(Destroy);
        pillairs.Clear();
    }
}
