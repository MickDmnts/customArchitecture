using UnityEngine;

public class EnemyController : MonoBehaviour {
    
    private Material mat;

    private CubeEnemiesGameManager gameManager;

    public void Start() {
        mat = GetComponent<Renderer>().material;
        gameManager = CubeEnemiesGameManager.GetGameManager();
    }

    public void Update() {

        CubeEnemiesGameManager.GameState gameState = gameManager.getGameState();

        if (gameState == CubeEnemiesGameManager.GameState.IDLE) {
            mat.SetColor("_Color", Color.green);
        }

        else if (gameState == CubeEnemiesGameManager.GameState.ALERT) {
            mat.SetColor("_Color", Color.red);
        }

        Debug.LogFormat("[EnemyController] {0} state changed to {1}...", name, gameState);
    }
}
