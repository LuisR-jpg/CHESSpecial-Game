using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour
{
    void Start()
    {
        var b = GetComponent<Button>();
        b.onClick.AddListener(Dismiss);
    }
    public void Dismiss()
    {
        Destroy(transform.parent.gameObject);
    }
}
