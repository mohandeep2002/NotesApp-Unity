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


    #region CRUD Operations
    public void AddNewNode(string title, string description)
    {
        NotesNode node = new NotesNode();
        int number = GenerateUniqueNumber();
        while (number == -1)
        {
            number = GenerateUniqueNumber();
        }
        node.NoteID = number;
        node.Description = description;
        node.Title = title;
        dataFromForm.Add(node);
        CreateNewNodeUI(node);
    }

    public List<NotesNode> GetAllNodes()
    {
        return dataFromForm;
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
                Debug.Log("Came inside if " + i + " " + randomNumber);
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
        NodeData nodeData = node.GetComponent<NodeData>();
        nodeData.indexOfNode = newNode.NoteID;
        nodeData.nodeTitle = newNode.Title;
        nodeData.nodeDesp = newNode.Description;
        newUIPanel.name = nodeData.nodeTitle;
        newUIPanel.GetComponentInChildren<TextMeshProUGUI>().text = nodeData.nodeTitle;
        dataGenerated.Add(newUIPanel);
        AssignColor(newUIPanel.GetComponent<Image>());
    }
}
