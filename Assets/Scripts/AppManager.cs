using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    List<string> apps = new List<string>();
    public GameObject tabPrefab;
	public GameObject tabsBar;
    public AppManager instance;

	public OpenedProcesses openedProcesses;

	private void Start()
	{
		instance = this;
	}

	public void AddToTaskbar(string Name)
    {
		GameObject tab = Instantiate(tabPrefab, tabsBar.transform);
		tab.name = Name;
		tab.transform.Find("Name").GetComponent<TMP_Text>().text = Name;
		Resource resource = new Resource(tab,1,1,1,1);
		openedProcesses.AddProcess(resource);

	}

	public void DeleteFromTaskbar(string Name)
	{
		GameObject tab = tabsBar.transform.Find(Name).gameObject;
		Destroy(tab);
		openedProcesses.RmProcess(new Resource(tab, 1, 1, 1, 1));
	}
}
