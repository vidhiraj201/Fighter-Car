using UnityEngine.EventSystems;
using UnityEngine;

public class AmmoShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
