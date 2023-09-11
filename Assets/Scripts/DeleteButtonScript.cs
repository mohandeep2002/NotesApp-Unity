using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButtonScript : MonoBehaviour
{
    public Image actualImage;
    private void OnEnable()
    {
        StartCoroutine(DelayToOff());
    }

    IEnumerator DelayToOff()
    {
        yield return new WaitForSeconds(2f);
        actualImage.enabled = true;
        gameObject.SetActive(false);
    }
}
