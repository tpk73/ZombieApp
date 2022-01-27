using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ManagerJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image joystickBG;
    private Image joystick;
    private Vector2 posInput;

    // Start is called before the first frame update
    void Start()
    {
        joystickBG = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG.rectTransform, 
            eventData.position, 
            eventData.pressEventCamera, 
            out posInput))
        {
            posInput.x = posInput.x / (joystickBG.rectTransform.sizeDelta.x);
            posInput.y = posInput.y / (joystickBG.rectTransform.sizeDelta.y);
            Debug.Log(posInput.x.ToString() + " " + posInput.y.ToString());

            if( posInput.magnitude > 1.0f)
            {
                posInput = posInput.normalized;
            }

            joystick.rectTransform.anchoredPosition = new Vector2(
                posInput.x * (joystickBG.rectTransform.sizeDelta.x / 2), posInput.y * (joystickBG.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        posInput = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float inputHorizontal()
    {
        if (posInput.x != 0)
        {
            return posInput.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }
    public float inputVertical()
    {
        if (posInput.y != 0)
        {
            return posInput.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }


}
