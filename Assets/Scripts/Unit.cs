using UnityEngine;

public class Unit : MonoBehaviour
{
    public float Speed;
    public Vector2 Direction;

    private void Update()
    {
        var dir = Time.deltaTime * Speed * new Vector3(Direction.x, 0f, Direction.y);
        transform.Translate(dir);
    }
}
