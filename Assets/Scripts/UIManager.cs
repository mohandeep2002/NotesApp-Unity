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
            placeHolderHomePage.gameObject.SetActive(true);
            infoPanel.gameObject.SetActive(false);
            print("infopanel Active");
        }
        else
        {
            print("infopanel Deactive");
            placeHolderHomePage.gameObject.SetActive(false);
            infoPanel.gameObject.SetActive(true);
        }
    }
    #endregion
}
