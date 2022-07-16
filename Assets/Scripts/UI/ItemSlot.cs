using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Drag and drop from https://www.youtube.com/watch?v=BGr-7GZJNXg&ab_channel=CodeMonkey

public class ItemSlot : MonoBehaviour, IDropHandler
{

    bool isFull = false;

    DragDrop item;

    public string currentName;

    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            if (!isFull)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                isFull = true;
                item = eventData.pointerDrag.GetComponent<DragDrop>();
                item.onDieLifted += Release;
                currentName = item.name;
            }
        }
    }

    public void Release()
    {
        item.onDieLifted -= Release;
        isFull = false;
        currentName = "";
    }

}
