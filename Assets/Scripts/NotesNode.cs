using System;
using UnityEngine;

[Serializable]
public class NotesNode
{
    [SerializeField] private int _noteID;
    [SerializeField] private string _title;
    [SerializeField] private string _description;

    #region Props
    public string Description { get => _description; set => _description = value; }
    public string Title { get => _title; set => _title = value; }
    public int NoteID { get => _noteID; set => _noteID = value; }
    #endregion
}
