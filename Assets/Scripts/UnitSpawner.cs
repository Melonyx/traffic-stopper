using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public float Speed = 2f;
    public Vector2 Direction;
    public float Duration = 5f;
    public Unit Prefab;

    private List<Unit> _cars;

    private static Rect _area = new Rect(new Vector2(-15f, -15f), new Vector2(30f, 30f));

    private void Start()
    {
        _cars = new List<Unit>();
        StartCoroutine(CreateCar());
        StartCoroutine(DestoryOldCars());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private Unit InstantiateCar()
    {
        var instance = Instantiate(Prefab, transform);
        instance.transform.localPosition = Vector3.zero;
        instance.transform.localRotation = Quaternion.identity;
        instance.Direction = Direction;
        instance.Speed = Speed;

        return instance;
    }

    private IEnumerator CreateCar()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            yield return new WaitForSeconds(Duration);
            var car = InstantiateCar();
            _cars.Add(car);
            yield return null;
        }
    }

    private IEnumerator DestoryOldCars()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            yield return new WaitForSeconds(2f * Duration);

            var toRemove = new List<Unit>();
            for (var i = 0; i < _cars.Count; i++)
            {
                var pos = new Vector2(_cars[i].transform.position.x, _cars[i].transform.position.z);
                if (!_area.Contains(pos))
                {
                    Destroy(_cars[i].gameObject);
                    toRemove.Add(_cars[i]);
                    yield return null;
                }
            }
            _cars.RemoveAll(c => toRemove.Contains(c));
        }
    }
}
