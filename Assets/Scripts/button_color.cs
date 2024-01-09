using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class button_color : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public TMP_Text buttonText;
    public Color buttonHoverColor;
    public Color buttonBasicColor;



    public void OnPointerEnter(PointerEventData eventData)
    {

        buttonText.color = buttonHoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        buttonText.color = buttonBasicColor;
    }
}
