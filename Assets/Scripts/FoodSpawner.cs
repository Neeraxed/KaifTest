using UnityEngine;
using System.Collections.Generic;

public class FoodSpawner : MonoBehaviour
{
    public List<Transform> FoodSpawnPoints = new List<Transform>(20);

    public void SpawnFood()
    {
        FoodSpawnPoints[Random.Range(0, FoodSpawnPoints.Count)].gameObject.SetActive(true);
    }
}
