using System.Collections.Generic;
using UnityEngine;

public class AppStartAntivirus : AppStart
{
	AntivirusHandler antivirusHandler;
	AntivirusSaveObj saveFile;

	public GameObject mainTab;
	public GameObject secTab;
	public GameObject repTab;
	public GameObject attchTab;

	public ToggleSwitchColorChange toggleSwitch0;
	public ToggleSwitchColorChange toggleSwitch1;
	public ToggleSwitchColorChange toggleSwitch2;

	public string currentTab;
	public List<bool> buttons;

	public override void OnOpen()
	{
		if (Resources.Load("AntivirusSave", typeof(AntivirusSaveObj)))
		{
			saveFile = Resources.Load<AntivirusSaveObj>("AntivirusSave");
			print("loaded");
		}
		else
			print("not loaded");

		antivirusHandler = GetComponent<AntivirusHandler>();
		antivirusHandler.saveObj = saveFile;

		 currentTab = saveFile.openedTab;
		buttons = saveFile.buttons;

		secTab.SetActive(true);
		toggleSwitch0.ToggleByGroupManager(buttons[0]);
		toggleSwitch1.ToggleByGroupManager(buttons[1]);
		toggleSwitch2.ToggleByGroupManager(buttons[2]);
		secTab.SetActive(false);

		if (currentTab == null || currentTab == "main")
			OpenTab(true, false, false, false);

		if (currentTab == "sec")
			OpenTab(false, true, false, false);

		if( currentTab == "rep")
			OpenTab(false, false, true, false);

		if (currentTab == "attch")
			OpenTab(false, false, false, true);

		
	}

	private void OpenTab(bool main, bool sec, bool rep, bool attch)
	{
		mainTab.SetActive(main);
		secTab.SetActive(sec);
		repTab.SetActive(rep);
		attchTab.SetActive(attch);
	}
}
