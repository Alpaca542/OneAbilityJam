using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCards : MonoBehaviour
{
    public GameObject CardPanel;
    public GameObject DeckButton;
    public void OnDeckClicked()
    {
        DeckButton.SetActive(false);
        CardPanel.SetActive(true);
    }
}
