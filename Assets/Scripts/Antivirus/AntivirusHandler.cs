using System.Collections.Generic;
using UnityEngine;

public class AntivirusHandler : MonoBehaviour
{
	public AntivirusSaveObj saveObj;

	public void SaveTab(string tab)
    {
		saveObj.openedTab = tab;
    }

    public void EnableFile(bool flag)
    {
		saveObj.buttons[0] = flag;
    }

	public void EnableWeb(bool flag)
	{
		saveObj.buttons[1] = flag;
	}

	public void EnableMail(bool flag)
	{
		saveObj.buttons[2] = flag;
	}
}
