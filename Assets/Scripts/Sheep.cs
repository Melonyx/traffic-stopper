using UnityEngine;

public class Sheep : Unit
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.GetComponent<Car>() != null)
        {
            Handheld.Vibrate();
        }
    }
}
