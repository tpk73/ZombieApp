using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    public int speed = 10;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Vector3 touchPosistion = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 15));
                transform.position = touchPosistion;

                touchPosistion *= Time.deltaTime;

                // Move object
                transform.Translate(touchPosistion * speed);
            }
        }
    }
}
