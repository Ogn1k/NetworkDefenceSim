using Aspose.Email;
using MimeKit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMailSave", menuName = "Custom/MailSave")]
public class MailSaveObj : ScriptableObject
{
    public string name;

    public List<MimeMessage> savedMailsDeleted;
    public ObservableCollection<MimeMessage> savedMails;

    public List<string> savedMailsSTR;
	public List<string> savedDeletedMailsSTR;

    public void CleanUp()
    {
        savedDeletedMailsSTR = new List<string>();
		savedMailsSTR = new List<string>();
		savedMailsDeleted = new List<MimeMessage>();
		savedMails = new ObservableCollection<MimeMessage>();
	}

}
