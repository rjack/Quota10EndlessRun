using System.Collections;
using UnityEngine;

public class SquareManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private GameObject actorPedestrianPrefab;
    [SerializeField] private GameObject otherPedestrianPrefab;
    [SerializeField] private GameObject policePedestrianPrefab;

    [SerializeField] private float pedestrianSpawnInterval = 0.5f;
    [SerializeField] private float numberOfPedestriansToSpawn = 2f;

    [SerializeField] private int maxPedestriansInSquare = 50;
    private int currentPedestrianCount = 0;

    [SerializeField] private float percentActorPedestrians = 0.5f;

    [SerializeField] private Collider EntryPoint;

    private void Start()
    {
        StartCoroutine(SpawnPassants());
    }

    private IEnumerator SpawnPassants()
    {
        // Spawn Pedestrians
        for (int i = 0; i < numberOfPedestriansToSpawn; i++)
        {
            if (currentPedestrianCount >= maxPedestriansInSquare)
            {
                yield break;
            }

            SpawnPedestrian();
        }

        yield return new WaitForSeconds(pedestrianSpawnInterval);

        StartCoroutine(SpawnPassants());

    }

    private GameObject RandomPedestrian()
    {
        float rand = Random.Range(0f, 1f);
        if (rand <= percentActorPedestrians)
        {
            return actorPedestrianPrefab;
        }
        else
        {
            float policeRand = Random.Range(0f, 1f);
            if (policeRand <= 0.1f) // 10% chance to spawn police pedestrian
            {
                return policePedestrianPrefab;
            }
            else
            {
                return otherPedestrianPrefab;
            }
        }
    }

    private Transform RandomSpawnPoint()
    {
        int randIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randIndex];
    }

    private Transform ReachTheMostDistantPoint(Transform fromPoint)
    {
        Transform mostDistantPoint = spawnPoints[0];
        float maxDistance = Vector3.Distance(fromPoint.position, mostDistantPoint.position);
        foreach (Transform point in spawnPoints)
        {
            float distance = Vector3.Distance(fromPoint.position, point.position);
            if (distance > maxDistance)
            {
                maxDistance = distance;
                mostDistantPoint = point;
            }
        }
        return mostDistantPoint;
    }

    private void SpawnPedestrian()
    {
        GameObject pedestrianPrefab = RandomPedestrian();
        Transform spawnPoint = RandomSpawnPoint();
        Transform targetPoint = ReachTheMostDistantPoint(spawnPoint);
        GameObject pedestrian = Instantiate(pedestrianPrefab, spawnPoint.position, spawnPoint.rotation);
        Passant passant = pedestrian.GetComponent<Passant>();
        if (passant != null)
        {
            passant.SetTarget(targetPoint);
        }
        currentPedestrianCount++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SpawnPassants());

            EntryPoint.enabled = false;
        }
    }
}
