using UnityEngine;
using TMPro;
using System.Text;

public class UIManager : MonoBehaviour,
    ITimeUpdateObserver
{
    /// <summary>
    /// The text displaying the time in the UI.
    /// </summary>
    [SerializeField,Tooltip("The text displaying the time in the UI.")] TextMeshProUGUI timeText;

    StringBuilder sb = new StringBuilder();

    private void Start()
    {
        PlayerChaseGameManager.GetGameManager().AddTimeUpdateObserver(this);
    }

    public void OnTimeUpdate(float time)
    {
        sb.Clear();

        sb.Append("Time: ");
        sb.Append(time);
        timeText.SetText(sb.ToString());
    }

    private void OnDestroy()
    {
        PlayerChaseGameManager.GetGameManager().RemoveTimeUpdateObserver(this);
    }
}
