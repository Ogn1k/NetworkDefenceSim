using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AntivirusSave", menuName = "Custom/AntivirusSave")]
public class AntivirusSaveObj : ScriptableObject
{
    public List<bool> buttons;
	public string openedTab;
	private bool created = false;

	public void newButtons()
	{
		if(!created) 
		{ 
			buttons = new List<bool>() { false,false,false};
			created = true;	
		}
	}
}
