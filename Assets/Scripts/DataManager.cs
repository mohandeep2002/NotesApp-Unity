using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    [Header("Generating components")]
    public List<NotesNode> dataFromForm = new List<NotesNode>();
    private HashSet<int> usedNumbers = new HashSet<int>();
    [Header("Generation UI Component")]
    [SerializeField]
    private GameObject node;
    public RectTransform content;
    public int colorCount = 0;
    public List<Color> colors = new List<Color>();
    public List<GameObject> dataGenerated = new List<GameObject>();
    [Header("UI Manager")]
    [SerializeField]
    private UIManager uIManager;

    #region CRUD Operations
    public void AddNewNode(string title, string description)
    {
        NotesNode node = new NotesNode();
        int number = GenerateUniqueNumber();
        Debug.Log("Generated number is " + number);
        while (number == -1)
        {
            number = GenerateUniqueNumber();
        }
        node.NoteID = number;
        // Debug.Log("Generated number and assigned number after logic NODE.NOTEID:" + node.NoteID + " NUMBER:" + number);
        node.Description = description;
        node.Title = title;
        dataFromForm.Add(node);
        CreateNewNodeUI(node);
    }

    public List<NotesNode> GetAllNodes()
    {
        return dataFromForm;
    }

    public void DeleteNode(int id)
    {
        // Debug.Log("DeleteNode function called " + id);
        for (int i = 0; i < dataFromForm.Count; i++)
        {
            if (id == dataFromForm[i].NoteID)
            {
                dataFromForm.RemoveAt(i);
                DeleteUI(id);
                break;
            }
        }
    }

    public void UpdateNote(string id, string nodeTitle, string nodeDescription)
    {
        foreach (var data in dataFromForm)
        {
            if (data.NoteID == int.Parse(id))
            {
                data.Title = nodeTitle;
                data.Description = nodeDescription;
                break;
            }
        }
        foreach (var data in dataGenerated)
        {
            if (data.name.Equals(id))
            {
                NodeData tempData = data.GetComponent<NodeData>();
                tempData.nodeDesp = nodeDescription;
                tempData.nodeTitle = nodeTitle;
                break;
            }
        }
    }

    #endregion

    private int GenerateUniqueNumber()
    {
        int maxAttempts = 1000;
        for (int i = 0; i < maxAttempts; i++)
        {
            int randomNumber = Random.Range(100, 1000);
            if (!usedNumbers.Contains(randomNumber))
            {
                usedNumbers.Add(randomNumber);
                // Debug.Log("Came inside if " + i + " " + randomNumber);  
                return randomNumber;
            }
        }
        Debug.LogWarning("Unable to generate a unique 3-digit number.");
        return -1;
    }

    private void AssignColor(Image panelImage)
    {
        if (colorCount == colors.Count)
        {
            colorCount = 0;
            panelImage.color = colors[colorCount];
        }
        else
        {
            panelImage.color = colors[colorCount];
        }
        colorCount++;
    }

    private void CreateNewNodeUI(NotesNode newNode)
    {
        GameObject newUIPanel = Instantiate(node, content);
        NodeData nodeData = newUIPanel.GetComponent<NodeData>();
        nodeData.indexOfNode = newNode.NoteID;
        // Debug.Log("===nodeData.indexOfNode:" + nodeData.indexOfNode);
        nodeData.nodeTitle = newNode.Title;
        nodeData.nodeDesp = newNode.Description;
        newUIPanel.name = nodeData.indexOfNode.ToString();
        // Debug.Log("CreatingNewNodeUI nodeData.indexOfNode:" + nodeData.indexOfNode + " newNode.NoteID:" + newNode.NoteID + " newUIPanel.name:" + newUIPanel.name);
        newUIPanel.GetComponentInChildren<TextMeshProUGUI>().text = nodeData.nodeTitle;
        dataGenerated.Add(newUIPanel);
        AssignColor(newUIPanel.GetComponent<Image>());
    }

    private void DeleteUI(int id)
    {
        for (int i = 0; i < dataGenerated.Count; i++)
        {
            if (id == dataGenerated[i].GetComponent<NodeData>().indexOfNode)
            {
                Destroy(dataGenerated[i]);
                dataGenerated.RemoveAt(i);
                break;
            }
        }
    }

    public void ShowNoteToEdit(int id)
    {
        foreach (var data in dataGenerated)
        {
            if (data.name.Equals(id.ToString()))
            {
                Debug.Log("Yes this is it");
                NodeData tempNodeData = data.GetComponent<NodeData>();
                uIManager.ShowDataToEdit(tempNodeData.indexOfNode, tempNodeData.nodeTitle, tempNodeData.nodeDesp);
                break;
            }
        }
        // uIManager.ShowDataToEdit();
    }

    public void MakeAllIsHoldingFalse()
    {
        foreach (var node in dataGenerated)
        {
            NodeData tempNode = node.GetComponent<NodeData>();
            tempNode.isHolding = false;
        }
    }
}
