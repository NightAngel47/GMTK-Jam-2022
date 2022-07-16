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
            return Instantiate(enemyPrefabs[(int)type], GetRandomSpawnPoint().position, Quaternion.identity, EnemyController.Instance.transform).GetComponent<EnemyBehaviour>();
        }

        private Transform GetRandomSpawnPoint()
        {
            Transform point = null;
            bool occupied = false;
            Vector3 dist = Vector3.zero;

            do
            {
                point = spawnPoints[Random.Range(1, spawnPoints.Count)];
                occupied = Physics2D.CircleCast(point.position, 0.5f, Vector2.zero);

                dist = PlayerController.Instance.transform.position - point.position;
            } while (!occupied && (dist.x >= minSpawnDist.x || dist.y >= minSpawnDist.y));

            return point;
        }
    }
}