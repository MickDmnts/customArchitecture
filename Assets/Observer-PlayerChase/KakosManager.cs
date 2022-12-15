using UnityEngine;



public class KakosManager: MonoBehaviour, IStageFinishedObserver {

    public void OnStageFinished() {
        Debug.Log("Oh no!");
    }

    public void Start() {
        PlayerChaseGameManager.GetGameManager().AddStageFinishedObserver(this);
    }

    public void Update() {

    }
}
