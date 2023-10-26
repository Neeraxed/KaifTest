using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HomemadeJoystick : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image background;
    [SerializeField] private Image knob;

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
