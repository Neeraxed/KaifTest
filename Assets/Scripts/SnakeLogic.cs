using UnityEngine;
using System.Collections.Generic;

public class SnakeLogic : MonoBehaviour
{
    [SerializeField] private GameObject bodyPrefab;
    [SerializeField] private FoodSpawner foodSpawner;
    [SerializeField] private int gap = 20;
    [SerializeField] private int bodySpeed = 5;

    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();
    private List<Quaternion> RotationsHistory = new List<Quaternion>();

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GrowSnake();
        }

        PositionsHistory.Insert(0, transform.position);
        RotationsHistory.Insert(0, transform.rotation);

        int index = 0;
        foreach(var item in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Min(index * gap, PositionsHistory.Count - 1)];
            Vector3 moveDirection = point - item.transform.position;
            item.transform.position += moveDirection * bodySpeed * Time.deltaTime;
            item.transform.rotation = RotationsHistory[Mathf.Min(index * gap, RotationsHistory.Count - 1)];
            index++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Food"))
        {
            GrowSnake();
            collision.gameObject.SetActive(false);
            foodSpawner.SpawnFood();
        }
        Debug.Log("Collision entered");
    }

    private void GrowSnake()
    {
        GameObject body = Instantiate(bodyPrefab, transform.localPosition, Quaternion.identity, transform);
        BodyParts.Add(body);
    }
}
