using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    List<string> apps = new List<string>();
    public GameObject tabPrefab;
	public GameObject tabsBar;
    public AppManager instance;

	private void Start()
	{
		instance = this;
	}

	public void AddToTaskbar(string Name)
    {
		GameObject tab = Instantiate(tabPrefab, tabsBar.transform);
		tab.name = Name;
		tab.transform.Find("Name").GetComponent<TMP_Text>().text = Name;
    }

	public void DeleteFromTaskbar(string Name)
	{
		GameObject.Destroy(transform.Find(Name));
	}
}
