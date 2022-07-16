using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class EnemySpawner : MonoBehaviour
    {
        public static EnemySpawner Instance { get; private set; }
        [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>();

        [Space]

        [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

        [SerializeField] private Vector2 minSpawnDist = new Vector2(5, 3);

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            spawnPoints.AddRange(GetComponentsInChildren<Transform>(true));
        }

        public EnemyBehaviour SpawnEnemy(Combat.EnemyTypes type)
        {
            Transform spawnPos = GetRandomSpawnPoint();
            
            return spawnPos ? Instantiate(enemyPrefabs[(int)type], spawnPos.position, Quaternion.identity, EnemyController.Instance.transform).GetComponent<EnemyBehaviour>() : null;
        }

        private Transform GetRandomSpawnPoint()
        {
            Transform point = null;
            bool occupied = false;
            Vector3 dist = Vector3.zero;

            List<Transform> spawnPointsToCheck = spawnPoints;

            do
            {
                point = spawnPointsToCheck[Random.Range(0, spawnPointsToCheck.Count)];
                spawnPointsToCheck.Remove(point);
                
                occupied = Physics2D.CircleCast(point.position, 0.5f, Vector2.zero);

                dist = PlayerController.Instance.transform.position - point.position;
                
                Debug.Log($"Point checked was Occupied: {occupied} & Distance was: {dist}");
            } while (!occupied && (dist.x >= minSpawnDist.x && dist.y >= minSpawnDist.y) || spawnPointsToCheck.Count == 0);

            // handle not finding a point
            if (spawnPointsToCheck.Count == 0)
            {
                point = null;
            }
            
            return point;
        }
    }
}