using TMPro;
using UnityEngine;

public class StatsUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _sheepsCounter;

    private void Update()
    {
        _sheepsCounter.text = Stats.Sheeps.ToString();
    }
}
