using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime;

    public GameObject target;
    public GameObject gameManager;

    GameManager manager;
    TargetScore score;

    public bool hasTargetSpawned;

    void Start()
    {
        manager = gameManager.GetComponent<GameManager>();
        score = GetComponentInChildren<TargetScore>();
        hasTargetSpawned = false;
        target.SetActive(false);
    }

    void Update()
    {
        if (!hasTargetSpawned)
        {
            if (manager.currentTimer == spawnTime)
            {
                target.SetActive(true);
                hasTargetSpawned = true;
                score.StartTimer();
            }
        }
    }
}
