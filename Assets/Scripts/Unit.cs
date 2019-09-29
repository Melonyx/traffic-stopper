using UnityEngine;

public class Unit : MonoBehaviour
{
    public float Speed;
    public Vector3 Direction { get; set; }

    private void Update()
    {
        var dir = Time.deltaTime * Speed * Direction;
        transform.position += dir;
    }
}
