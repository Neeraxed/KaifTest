using UnityEngine;
using System.Collections.Generic;

public class SnakeLogic : MonoBehaviour
{
    [SerializeField] private GameObject bodyPrefab;
    [SerializeField] private GameObject food;
    [SerializeField] private int gap = 20;
    [SerializeField] private int bodySpeed = 5;

    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    private void Start()
    {
        GrowSnake();
    }

    private void FixedUpdate()
    {
        PositionsHistory.Insert(0, transform.position);

        int index = 0;
        foreach(var item in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Min(index * gap, PositionsHistory.Count - 1)];
            Vector3 moveDirection = point - item.transform.position;
            item.transform.position += moveDirection * bodySpeed * Time.deltaTime;
            item.transform.LookAt(point);
            index++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Food"))
        {
            GrowSnake();
            FoodManager.avaliableFood.Add(collision.gameObject);
            collision.gameObject.SetActive(false);
            FoodManager.SpawnFood();
        }
        Debug.Log("Collision entered");
    }

    private void GrowSnake()
    {
        GameObject body = Instantiate(bodyPrefab, transform.localPosition, Quaternion.identity);
        BodyParts.Add(body);
    }
}
