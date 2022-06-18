using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsManager 
{
    private static CoinsManager _instance = null;
    private static object _handle = new object();
	private TextMeshProUGUI text; 
	private int coins = 0;

    protected CoinsManager() { }
	public static CoinsManager Instance
	{
		get
		{
			lock (_handle)
			{
				if (_instance == null)
				{
					_instance = new CoinsManager();
				}
			}

			return _instance;
		}
	}
    public void SetText(GameObject txt)
    {
		coins = 0;
        text = txt.GetComponent<TextMeshProUGUI>();
        _instance.addCoins(10);
    }
    public void addCoins(int qty) 
    {
        coins += qty;
        text.text = coins.ToString();
    }
	public bool canAfford(int qty) 
	{
		return coins >= qty;
	}
	public IEnumerator TimeReward() 
	{
		while(true)
		{
			yield return new WaitForSecondsRealtime(1);
			addCoins(1);
		}
	}
}
