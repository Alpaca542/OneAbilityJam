using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardPlaceholder : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        dropped.GetComponent<Card>().parentAfterDrag = transform;
        GameObject.FindGameObjectWithTag("CardManager").GetComponent<ManageCards>().Deck.Add(dropped);
    }
}