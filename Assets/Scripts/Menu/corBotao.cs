using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeTextColorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text buttonText;
    private Color originalTextColor;

    private void Start()
    {
        buttonText = GetComponentInChildren<Text>();
        originalTextColor = buttonText.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = Color.red; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = originalTextColor;
    }
}
