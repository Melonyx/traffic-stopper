using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Car : Unit, IPointerClickHandler
{
    private float _lastSpeed;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Speed != 0f)
            StartCoroutine(StopWaitGo());
    }

    private IEnumerator StopWaitGo()
    {
        _lastSpeed = Speed;
        Speed = 0f;

        yield return new WaitForSeconds(3.5f);

        Speed = _lastSpeed;
    }
}
