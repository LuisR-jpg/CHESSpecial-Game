using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class EffectsHub : MonoBehaviour
{
    public GameObject bonusPanel;
    private Vector2 bonusSize;
    // Start is called before the first frame update
    void Start()
    {
        bonusSize = bonusPanel.GetComponent<Image>().rectTransform.sizeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        if(bonusPanel.activeInHierarchy)
        {
            var t = bonusPanel.GetComponent<Image>().rectTransform.sizeDelta;
            bonusPanel.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(t.x + 5, t.y);
        }
    }

    public void TriggerBonusEffect()
    {
        if (bonusPanel.activeInHierarchy) return;
        bonusPanel.SetActive(true);
        StartCoroutine(ResetBonusEffect());
    }
    
    IEnumerator ResetBonusEffect()
    {
        yield return new WaitForSeconds(2);
        bonusPanel.GetComponent<Image>().rectTransform.sizeDelta = bonusSize;
        bonusPanel.SetActive(false); 
    }
}
