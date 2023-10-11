using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NodeData : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Color nodeColor;
    public int indexOfNode;
    public string nodeTitle;
    public string nodeDesp;

    public bool isHolding = false;
    public bool isTouchedOnce = false;
    public float holdDuration = 0f;
    public Image actualImage;
    public GameObject buttonGameObject;
    public DataManager dataManager;

    private void Start()
    {
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
    }

    private void Update()
    {
        if (isHolding)
        {
            holdDuration += Time.deltaTime;
            if (holdDuration < 0.3f && isTouchedOnce == false)
            {
                Debug.Log("Clicked Once Only!!");
                isTouchedOnce = true;
                dataManager.ShowNoteToEdit(indexOfNode);
            }
            if (holdDuration >= 1f)
            {
                Debug.Log(holdDuration + " came inside");
                actualImage.enabled = false;
                buttonGameObject.SetActive(true);
            }
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        isHolding = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        isHolding = false;
        holdDuration = 0f;
        isTouchedOnce = false;
    }

    public void DeleteButtonClicked()
    {
        Debug.Log("Delete Button Clicked");
        dataManager.DeleteNode(indexOfNode);
    }
}
