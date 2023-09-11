using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeData : MonoBehaviour
{
    public Color nodeColor;
    public int indexOfNode;
    public string nodeTitle;
    public string nodeDesp;

    private bool isHolding = false;
    private float holdStartTime = 0f;
    public Image actualImage;
    public GameObject buttonGameObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isHolding = true;
            holdStartTime = Time.time;
        }

        if (isHolding && Input.GetMouseButton(0))
        {
            float holdDuration = Time.time - holdStartTime;
            if (holdDuration >= 1f)
            {
                Debug.Log(gameObject.name);
                actualImage.enabled = false;
                buttonGameObject.SetActive(true);
            }
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            isHolding = false;
        }
    }
}
