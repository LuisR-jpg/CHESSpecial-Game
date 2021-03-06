using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WallController : PieceBaseController
{
    TextMeshProUGUI text;
    public AudioClip damageAudio;
    private int level = 0;

    protected override void Start()
    {
        base.Start();
        string find = tag == "black"? "BlackIndicator": "WhiteIndicator";
        text = GameObject.Find("/Canvas/" + find + "/HP").GetComponent<TextMeshProUGUI>();
        text.text = strength.ToString();
    }
    // Ignore this method, this is just shitty design
    public override void MyFixedUpdate() { }
    // Ignore this method, this is just shitty design
    public override void Attack() { }

    public override void Damage(int damage, bool willBeDestroyed)
    {
        AudioSource.PlayClipAtPoint(damageAudio, transform.position, 1.0f);
        strength -= damage / 4;
        if (tag == "white") CoinsManager.Instance.addCoins(1); 
        strength = Mathf.Max(0, strength);
        text.text = strength.ToString();
        if(strength == 0)
        {
            string newScene = tag == "black"? "WhiteWins": "BlackWins";
            if(newScene == "BlackWins")
                PlayerPrefs.SetInt("Level" + (level + 1), 1);
            SceneManager.LoadScene(newScene);
        }
    }

    public void SetLevel(int l)
    {
        level = l;
    }
}
