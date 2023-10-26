using UnityEngine;
using System.Collections.Generic;

public static class FoodManager
{
    public static List<Transform> FoodSpawnPoints = new List<Transform>();
    public static List<GameObject> avaliableFood = new List<GameObject>();

    public static void SpawnFood()
    {
        foreach (var item in avaliableFood)
        {
            item.transform.position = FoodSpawnPoints[Random.RandomRange(0, FoodSpawnPoints.Count)].position;
            item.SetActive(true);
        }
    }
}
