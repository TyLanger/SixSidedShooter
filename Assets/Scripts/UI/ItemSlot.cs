using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Drag and drop from https://www.youtube.com/watch?v=BGr-7GZJNXg&ab_channel=CodeMonkey

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    protected bool isFull = false;

    protected UIDie item;

    public string currentName;

    public GameObject tooltip;

    public virtual void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            if (!isFull)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                isFull = true;
                item = eventData.pointerDrag.GetComponent<UIDie>();
                item.OnDieLifted += Release;
                currentName = item.name + ": " + item.GetValue();
            }
        }
    }

    public void Release()
    {
        if (item != null)
        {
            item.OnDieLifted -= Release;
        }
        isFull = false;
        currentName = "";
    }

    protected virtual void ShowToolTip()
    {
        if(tooltip)
        {
            tooltip.SetActive(true);
        }
    }

    protected virtual void HideToolTip()
    {
        if (tooltip)
        {
            tooltip.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowToolTip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideToolTip();
    }
}
