using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables
    [Header("Panels")]
    public GameObject placeHolderHomePage;
    public GameObject infoPanel;
    public GameObject mainPanel;
    public GameObject searchPanel;

    [Header("Texts")]
    public TMPro.TMP_InputField searchingText;

    [Header("Buttons")]
    public Button closeSearchButton;
    #endregion

    #region MonoBehaviour Functions
    private void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape) && searchPanel.gameObject.activeInHierarchy)
            {
                ToggleSearchPanel(false);
                ToggleMainPanel(true);
            }
        }

        if (searchingText.text.Length == 0) ToggleSearchCloseButton(false);
        else ToggleSearchCloseButton(true);
    }
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

    public void OnSearchButtonClicked()
    {
        ToggleMainPanel(false);
        ToggleSearchPanel(true);
    }
    #endregion

    #region UIEvents
    public void ToggleSearchCloseButton(bool state)
    {
        closeSearchButton.gameObject.SetActive(state);
    }

    public void ToggleInfoPanel(bool state)
    {
        infoPanel.gameObject.SetActive(state);
    }

    public void TogglePlaceHolders(bool state)
    {
        placeHolderHomePage.gameObject.SetActive(state);
    }

    public void ToggleSearchPanel(bool state)
    {
        searchPanel.gameObject.SetActive(state);
    }

    public void ToggleMainPanel(bool state)
    {
        mainPanel.gameObject.SetActive(state);
    }
    #endregion
}
