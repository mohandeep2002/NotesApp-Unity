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
    public GameObject editNotePanel;
    public GameObject editNoteDiscardChangesPanel;

    [Header("Text for searching")]
    public TMPro.TMP_InputField searchingText;
    [Header("Text for New note panel")]
    public TMPro.TMP_InputField titleText;
    public TMPro.TMP_InputField descriptionText;

    [Header("Buttons")]
    public Button closeSearchButton;

    [Header("Data Manager")]
    public DataManager dataManager;

    [Header("Texts for edit note panel")]
    public TMPro.TMP_InputField editTitleText;
    public TMPro.TMP_InputField editDescriptionText;
    public TMPro.TextMeshProUGUI editedIndexNumber;

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
        if (dataManager.GetAllNodes().Count > 0) TogglePlaceHolders(false);
    }

    #endregion

    #region ButtonClicks

    #region MainPanelClicks
    public void OnInfoButtonClicked()
    {
        if (infoPanel.activeInHierarchy)
        {
            ToggleInfoPanel(false);
            if (dataManager.GetAllNodes().Count == 0) TogglePlaceHolders(true);
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

    #region EditNotesPanelClicks
    public void EditButtonClicked()
    {
        editDescriptionText.interactable = true;
        editTitleText.interactable = true;
    }

    public void BackButtonClickedInEditNote()
    {
        editDescriptionText.text = "";
        editTitleText.text = "";
        editedIndexNumber.text = "";
        ToggleEditNotesPanel(false);
        ToggleMainPanel(true);
    }

    public void SaveButtonClickedInEditNote()
    {
        Debug.Log("ConfirmSave clicked");
        if (editDescriptionText.text.Length != 0 && editTitleText.text.Length != 0)
        {
            dataManager.UpdateNote(editedIndexNumber.text, editTitleText.text, editDescriptionText.text);
            BackButtonClickedInEditNote();
        }
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
        if (state) dataManager.MakeAllIsHoldingFalse();
    }

    public void ToggleNewNotesPanel(bool state)
    {
        newNotesPanel.SetActive(state);
    }

    public void ToggleConfirmSavePanel(bool state)
    {
        saveConfirmationPanel.SetActive(state);
    }

    public void ToggleEditNotesPanel(bool state)
    {
        editNotePanel.SetActive(state);
    }

    public void ShowDataToEdit(int id, string heading, string description)
    {
        ToggleEditNotesPanel(true);
        ToggleMainPanel(false);
        editTitleText.text = heading;
        editDescriptionText.text = description;
        editedIndexNumber.text = id.ToString();
    }

    #endregion
}
