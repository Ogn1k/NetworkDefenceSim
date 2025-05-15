using System.Collections.Generic;
using UnityEngine;

public struct Mail
{
    string sender;
    string recievier;
    string message;
    string attachment;
}

public class MailBox : MonoBehaviour
{
    List<Mail> mails;
    public GameObject mailPrefab;
}
