using UnityEngine;

public class Human : Unit
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.GetComponent<Car>() != null)
        {
            Handheld.Vibrate();
        }
    }
}
