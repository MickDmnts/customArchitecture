using UnityEngine;
using UnityEngine.AI;

public class EnemyHandler: MonoBehaviour, 
    IStageFinishedObserver 
{
    [SerializeField] float startSpeed = 2f;

    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Start() 
    {
        PlayerChaseGameManager.GetGameManager().AddStageFinishedObserver(this);

        agent.speed = startSpeed;
    }

    public void OnStageFinished()
    {
        agent.speed *= 0.5f;
    }

    private void OnDestroy()
    {
        PlayerChaseGameManager.GetGameManager().RemoveStageFinishedObserver(this);
    }
}
