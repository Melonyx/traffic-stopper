using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _sheepsCounter;
    [SerializeField] private GameObject _heartsRoot;

    private Image[] _hearts;
    private int _heartCount;

    private void Start()
    {
        _hearts = _heartsRoot.GetComponentsInChildren<Image>();
        _heartCount = _hearts.Length;
    }

    private void Update()
    {
        _sheepsCounter.text = Stats.Sheeps.ToString();
        if (_heartCount > Stats.Lifes)
        {
            _hearts[_heartCount - 1].gameObject.SetActive(false);
            _heartCount--;
        }
    }
}
