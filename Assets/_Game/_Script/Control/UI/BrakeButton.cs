using UnityEngine.EventSystems;
using UnityEngine;

public class BrakeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isBrakePressed;
    public void OnPointerDown(PointerEventData eventData)
    {
        isBrakePressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBrakePressed = false;
    }
    private void Update()
    {
        if (FindObjectOfType<FCar.core.GameManager>().GameOver)
        {
            Destroy(GetComponent<BrakeButton>());
        }
    }
}
