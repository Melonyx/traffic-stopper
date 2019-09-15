using UnityEngine;
using UnityEngine.EventSystems;

public class Unit : MonoBehaviour, IPointerClickHandler
{
    public float Speed;
    public Vector2 Direction;

    private float _speed;

    private void Start()
    {
        _speed = Speed;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _speed = _speed == 0f ? Speed : 0f;
    }

    private void Update()
    {
        var dir = Time.deltaTime * _speed * new Vector3(Direction.x, 0f, Direction.y);
        transform.Translate(dir);
    }
}
