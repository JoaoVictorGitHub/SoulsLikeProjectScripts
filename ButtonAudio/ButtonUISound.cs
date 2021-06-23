using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonUISound : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public AudioSource hoover;
    public AudioSource click;


    public void OnPointerEnter(PointerEventData eventData)
    {
        hoover.Play();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        click.Play();
    }
}