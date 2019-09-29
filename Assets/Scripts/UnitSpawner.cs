using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public float Speed = 2f;

    [SerializeField] private Vector2 _direction;
    public Vector3 Direction { get; set; }
    public float Duration = 5f;
    public Unit Prefab;

    private List<Unit> _units;

    private static Rect _area = new Rect(new Vector2(-25f, -25f), new Vector2(60f, 60f));

    private void Awake()
    {
        Direction = new Vector3(_direction.x, 0f, _direction.y);
    }

    private void Start()
    {
        _units = new List<Unit>();
        StartCoroutine(CreateUnit());
        StartCoroutine(DestoryOldUnits());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private Unit InstantiateUnit()
    {
        var instance = Instantiate(Prefab, transform);
        instance.transform.localPosition = Vector3.zero;
        instance.transform.LookAt(transform.position - Direction);
        instance.Direction = Direction;
        instance.Speed = Speed;

        return instance;
    }

    private IEnumerator CreateUnit()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            yield return new WaitForSeconds(Duration);
            var car = InstantiateUnit();
            _units.Add(car);
            yield return null;
        }
    }

    private IEnumerator DestoryOldUnits()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            yield return new WaitForSeconds(2f * Duration);

            var toRemove = new List<Unit>();
            for (var i = 0; i < _units.Count; i++)
            {
                var pos = new Vector2(_units[i].transform.position.x, _units[i].transform.position.z);
                if (!_area.Contains(pos))
                {
                    Destroy(_units[i].gameObject);
                    toRemove.Add(_units[i]);
                    yield return null;
                }
            }
            _units.RemoveAll(c => toRemove.Contains(c));
        }
    }
}
