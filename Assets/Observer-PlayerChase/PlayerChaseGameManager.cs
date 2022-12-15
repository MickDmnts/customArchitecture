using System.Collections.Generic;
using UnityEngine;

public class PlayerChaseGameManager : MonoBehaviour {

    private List<IStageFinishedObserver> stageFinishedObservers;

    public void AddStageFinishedObserver(IStageFinishedObserver observer) {
        stageFinishedObservers.Add(observer);
    }

    public void RemoveStageFinishedObserver(IStageFinishedObserver observer) {
        stageFinishedObservers.Remove(observer);
    }

    private static PlayerChaseGameManager inst;

    public static PlayerChaseGameManager GetGameManager() {
        return inst;
    }

    [SerializeField]
    private float stageTime;
    
    private float totalTime;

    public void Awake() {
        
        stageFinishedObservers = new List<IStageFinishedObserver>();
        
        inst = this;
    }

    public void Start() {

    }

    public void Update() {

        totalTime += Time.deltaTime;

        if (totalTime > stageTime) {

            totalTime = 0;

            foreach (IStageFinishedObserver observer in stageFinishedObservers) {
                observer.OnStageFinished();
            }
        }
    }

    public float GetTotalTime() {
        return totalTime;
    }
}
