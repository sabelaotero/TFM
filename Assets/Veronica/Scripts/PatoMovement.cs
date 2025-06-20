using System.Collections.Generic;
using UnityEngine;

public class PatoMovement : MonoBehaviour
{
    [SerializeField] private float minimaVelocidad = 1f;
    [SerializeField] private float maximaVelocidad = 10f;

    private List<Transform> pathPoints;
    private int currentIndex;
    private float speed;

    public void Initialize(List<Transform> points)
    {
        pathPoints = new List<Transform>(points);
        currentIndex = 0;
        speed = Random.Range(minimaVelocidad, maximaVelocidad);
    }

    private void Update()
    {
        if (pathPoints == null || currentIndex >= pathPoints.Count) 
            return;

        Transform target = pathPoints[currentIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            currentIndex++;
            if (currentIndex >= pathPoints.Count)
            {
                Destroy(gameObject);
            }
        }
    }
}