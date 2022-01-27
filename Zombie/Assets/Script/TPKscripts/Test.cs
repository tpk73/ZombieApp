using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public static Test test;
    public Transform player;
    Vector3 move;
    public float moveSpeed;

    bool walking;

    public RectTransform pad;
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * .8f);

        move = new Vector3(transform.localPosition.x, 0, transform.localPosition.y).normalized;

        if (!walking)
        {
            walking = true;
            player.GetComponent<Animator>().SetBool("IsMoving", true);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        move = Vector3.zero;
        StopCoroutine("PlayerMove");

        walking = false;
        player.GetComponent<Animator>().SetBool("IsMoving", false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine("PlayerMove");
    }

    IEnumerator PlayerMove()
    {
        while (true)
        {
            player.Translate(move * moveSpeed * Time.deltaTime, Space.World);

            if(move != Vector3.zero)
            {
                player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(move), 5 * Time.deltaTime);
            }

            yield return null;
        }
    }
}
