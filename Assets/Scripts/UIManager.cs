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
    public GameObject newNotesPanel;
    public GameObject saveConfirmationPanel;

    [Header("Texts")]
    public TMPro.TMP_InputField searchingText;
    public TMPro.TMP_InputField titleText;
    public TMPro.TMP_InputField descriptionText;

    [Header("Buttons")]
    public Button closeSearchButton;

    [Header("Data Manager")]
    public DataManager dataManager;

    #endregion

    #region MonoBehaviour Functions

    private void FixedUpdate()
    {
        if (searchingText.text.Length == 0) ToggleSearchCloseButton(false);
        else ToggleSearchCloseButton(true);

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                if (searchPanel.activeInHierarchy)
                {
                    ToggleSearchPanel(false);
                    ToggleMainPanel(true);
                }
                else if (newNotesPanel.activeInHierarchy)
                {
                    ToggleNewNotesPanel(false);
                    ToggleMainPanel(true);
                }
            }
        }
    }

    #endregion

    #region ButtonClicks

    #region MainPanelClicks
    public void OnInfoButtonClicked()
    {
        if (infoPanel.activeInHierarchy)
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

    public void PlusButtonClicked()
    {
        ToggleNewNotesPanel(true);
        ToggleMainPanel(false);
    }
    #endregion

    #region NewNotesPanel
    public void BackButtonClickInNew()
    {
        ToggleMainPanel(true);
        ToggleNewNotesPanel(false);
    }

    public void SaveButtonClicked()
    {
        if (!(titleText.text.Length == 0 || descriptionText.text.Length == 0))
        {
            saveConfirmationPanel.SetActive(true);
        }
    }
    public void ConfirmSaveData()
    {
        dataManager.AddNewNode(titleText.text, descriptionText.text);
        titleText.text = "";
        descriptionText.text = "";
        ToggleConfirmSavePanel(false);
        BackButtonClickInNew();
    }

    #endregion

    #endregion

    #region UIEvents
    public void ToggleSearchCloseButton(bool state)
    {
        closeSearchButton.gameObject.SetActive(state);
    }

    public void ToggleInfoPanel(bool state)
    {
        infoPanel.SetActive(state);
    }

    public void TogglePlaceHolders(bool state)
    {
        placeHolderHomePage.SetActive(state);
    }

    public void ToggleSearchPanel(bool state)
    {
        searchPanel.SetActive(state);
    }

    public void ToggleMainPanel(bool state)
    {
        mainPanel.SetActive(state);
    }

    public void ToggleNewNotesPanel(bool state)
    {
        newNotesPanel.SetActive(state);
    }

    public void ToggleConfirmSavePanel(bool state)
    {
        saveConfirmationPanel.SetActive(state);
    }

    #endregion
}
