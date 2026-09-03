using UnityEngine;

public class TargetDestroy : MonoBehaviour
{
    TargetScore score;
    Spawner spawn;

    void Start()
    {
        score = GetComponent<TargetScore>();
        spawn = GetComponentInParent<Spawner>();
    }

    public void GetScore()
    {
        score.UpdateScore();
        destoryTarget();
    }

    public void destoryTarget()
    {
        spawn.manager.hitScore += 1f;
        spawn.manager.UpdateHits();
        Destroy(this.gameObject);
    }
}
