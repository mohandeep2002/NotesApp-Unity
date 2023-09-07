using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Variables
    public RectTransform placeHolderHomePage;
    public RectTransform infoPanel;
    #endregion


    #region ButtonClicks
    public void OnInfoButtonClicked()
    {
        if (infoPanel.gameObject.activeInHierarchy)
        {
            ToggleInfoPanel(false);
            TogglePlaceHolders(true);
        }
        else
        {
            ToggleInfoPanel(true);
            TogglePlaceHolders(false);
        }
    }
    #endregion

    #region UIEvents
    public void ToggleInfoPanel(bool state)
    {
        infoPanel.gameObject.SetActive(state);
    }

    public void TogglePlaceHolders(bool state)
    {
        placeHolderHomePage.gameObject.SetActive(state);
    }
    #endregion
}
