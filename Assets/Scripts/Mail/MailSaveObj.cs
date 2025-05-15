using Aspose.Email;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMailSave", menuName = "Custom/MailSave")]
public class MailSaveObj : ScriptableObject
{
    public string name;

    public List<MailMessage> savedMailsDeleted;
    public List<MailMessage> savedMails;

    public List<string> savedMailsSTR;

    
}
