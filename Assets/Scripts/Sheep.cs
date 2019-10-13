using UnityEngine;

public class Sheep : Unit
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Car>() != null)
            Stats.Lifes--;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider == EndpointCollider)
            Stats.Sheeps++;
    }
}
