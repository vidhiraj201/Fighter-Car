using UnityEngine.EventSystems;
using UnityEngine;
public class AccelerateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isAcceleratorPressed;
    public void OnPointerDown(PointerEventData eventData)
    {
        isAcceleratorPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isAcceleratorPressed = false;
    }
    private void Update()
    {
        if (FindObjectOfType<FCar.core.GameManager>().GameOver)
        {
            Destroy(GetComponent<AccelerateButton>());
        }
    }
}
