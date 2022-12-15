using System.Collections.Generic;
using UnityEngine;

public class PlayerChaseGameManager : MonoBehaviour 
{
    List<IStageFinishedObserver> stageFinishedObservers;
    List<ITimeUpdateObserver> timeFinishedObservers;

    private static PlayerChaseGameManager inst;

    public static PlayerChaseGameManager GetGameManager() 
    {
        return inst;
    }

    [SerializeField] float stageTime;
    float totalTime;

    public void Awake() 
    {      
        stageFinishedObservers = new List<IStageFinishedObserver>();
        timeFinishedObservers = new List<ITimeUpdateObserver>();

        inst = this;
    }

    public void Update() 
    {
        totalTime += Time.deltaTime;

        foreach (ITimeUpdateObserver observer in timeFinishedObservers)
        {
            observer.OnTimeUpdate(totalTime);
        }

        if (totalTime > stageTime) 
        {
            totalTime = 0;

            foreach (IStageFinishedObserver observer in stageFinishedObservers) 
            {
                observer.OnStageFinished();
            }
        }
    }

    public float GetTotalTime() 
    {
        return totalTime;
    }

    public void AddStageFinishedObserver(IStageFinishedObserver observer)
    {
        stageFinishedObservers.Add(observer);
    }

    public void RemoveStageFinishedObserver(IStageFinishedObserver observer)
    {
        stageFinishedObservers.Remove(observer);
    }

    public void AddTimeUpdateObserver(ITimeUpdateObserver observer)
    {
        timeFinishedObservers.Add(observer);
    }

    public void RemoveTimeUpdateObserver(ITimeUpdateObserver observer)
    {
        timeFinishedObservers.Remove(observer);
    }
}
