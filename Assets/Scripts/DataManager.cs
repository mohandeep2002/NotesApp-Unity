using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public List<NotesNode> allData = new List<NotesNode>();

    public void AddNewNode(string title, string description)
    {
        NotesNode node = new NotesNode();
        node.NoteID = allData.Count + 1;
        node.Description = description;
        node.Title = title;
        allData.Add(node);
    }

    public List<NotesNode> GetAllNodes()
    {
        return allData;
    }
}
