using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] Obstacles;
    [SerializeField] private float Delay;
    [SerializeField] private Transform Parent;
    [SerializeField] private GameObject BackGroundPrefab;
    [SerializeField] private List<GameObject> BackGrounds;
    [SerializeField] private float MovingSpeed;

    /*private GameObject GetRandomObstacle()
    {
        return Obstacles[Random.Range(0, Obstacles.Length)];
    }

    private GameObject GenerateObstacle()
    {
        Vector3 Position = Vector3.zero + Vector3.up * 10f;
        Quaternion Rotation = Quaternion.identity;|

        GameObject Obstacle = Instantiate(GetRandomObstacle(), Position, Rotation, Parent);

        return Obstacle;
    }*/

    private void Start()
    {
        BackGrounds = new List<GameObject>();
        InvokeRepeating("Spawn", 0, Delay);
    }
    private void FixedUpdate()
    {
        foreach (GameObject backGround in BackGrounds.Where(x => x))
        {
            backGround.transform.position += Vector3.up * -MovingSpeed / 10f;
        }
    }
    private GameObject InstantiateBackground()
    {
        Vector3 Position = Vector3.zero + Vector3.up * 10f;
        Quaternion Rotation = Quaternion.identity;

        GameObject backGround = Instantiate(BackGroundPrefab, Position, Rotation);

        return backGround;
    }
    private void Spawn()
    {
        BackGrounds.Add(InstantiateBackground());

        Destroy(BackGrounds[BackGrounds.Count - 1].gameObject, Delay*5);

        BackGrounds = BackGrounds.Where(x => x).ToList();
    }
}
