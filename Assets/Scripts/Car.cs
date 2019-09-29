using UnityEngine.EventSystems;

public class Car : Unit, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Speed = Speed == 0f ? Speed : 0f;
    }
}
