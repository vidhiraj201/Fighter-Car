using UnityEngine.EventSystems;
using UnityEngine;

public class MissileShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isShootButtonPressed;
    public void OnPointerDown(PointerEventData eventData)
    {
        isShootButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isShootButtonPressed = false;
    }
}
