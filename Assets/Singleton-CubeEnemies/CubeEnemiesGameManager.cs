using UnityEngine;

public class CubeEnemiesGameManager: MonoBehaviour {

    public enum GameState {
        IDLE,
        ALERT
    };
    
    private float delay = 0;

    private GameState gameState;

    private static CubeEnemiesGameManager inst = null;

    public static CubeEnemiesGameManager GetGameManager() {

        /*
        if (inst == null) {
            inst = new GameManager();
        }
        */

        return inst;
    }

    private CubeEnemiesGameManager() {

    }

    public GameState getGameState() {
        return gameState;
    }

    public void Awake() {
        inst = this;
    }

    public void Start() {
        gameState = GameState.IDLE;
    }

    public void Update() {
        if (delay < 0) {
            delay = Random.Range(1.0f, 5.0f);
            gameState = gameState == GameState.IDLE ? GameState.ALERT : GameState.IDLE;
            Debug.LogFormat("[GameManager] Game state changed to {0}...", gameState);
        }
        else {
            delay -= Time.deltaTime;
        }
    }
}
