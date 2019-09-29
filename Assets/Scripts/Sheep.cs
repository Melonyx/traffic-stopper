using UnityEngine;

public class Sheep : Unit
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Car>() != null)
        {
            Handheld.Vibrate();
        }
    }
}
