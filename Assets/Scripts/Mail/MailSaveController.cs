using Unity.VisualScripting;
using UnityEngine;

public class MailSaveController : MonoBehaviour
{
    public string name;
    public MailMessageHandler messageHandler;
    public MailSaveObj saveFile;


    public void UpdateObjs()
    {
        if(messageHandler == null)
			messageHandler = GetComponent<MailMessageHandler>();

		if (Resources.Load("MailBoxes/"+name, typeof(MailSaveObj)))
        {
            saveFile = Resources.Load<MailSaveObj>("MailBoxes/" + name);

			print("loaded");
		}    
        else
        {
			print("not loaded");
        }
	}

	public void UpdateSave()
    {
        if(name == saveFile.name) 
        {
			saveFile.savedMails = messageHandler.mailMessages;
			saveFile.savedMailsDeleted = messageHandler.MailMessagesDeleted;
            saveFile.savedMailsSTR = messageHandler.mailMessagesSTRlist;
		}
    }

    public void LoadSave()
    {
        if (name == saveFile.name)
        {
            messageHandler.mailMessages = saveFile.savedMails;
            messageHandler.MailMessagesDeleted = saveFile.savedMailsDeleted;
            messageHandler.mailMessagesSTRlist = saveFile.savedMailsSTR;
            //messageHandler.UpdateMailBox();
		}
    }
}
