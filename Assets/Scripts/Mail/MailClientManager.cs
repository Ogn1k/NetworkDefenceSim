using System.Collections.Generic;
using System.IO;
using Aspose.Email;
using UnityEngine;

public class MailClientManager : MonoBehaviour
{
	public List<MailMessage> loadedEmails { get; private set; }
	private EmlProcessor emlProcessor;
	public MailClientManager instance;
	public List<MailMessage> LoadAllEmlFromFolder(string folderPath)
	{
		List<MailMessage> emails = new List<MailMessage>();

		// Получаем все файлы с расширением .eml
		string[] emlFiles = Directory.GetFiles(folderPath, "*.eml");

		foreach (string emlFile in emlFiles)
		{
			try
			{
				// Загружаем письмо из файла
				MailMessage message = MailMessage.Load(emlFile);
				emails.Add(message);
			}
			catch (System.Exception ex)
			{
				Debug.LogError($"Ошибка загрузки файла {emlFile}: {ex.Message}");
			}
		}

		return emails;
	}

	void Start()
    {
		instance = this;

		string folderPath = Application.dataPath + "/Emails"; // Путь к папке с EML
		loadedEmails = LoadAllEmlFromFolder(folderPath);

		Debug.Log($"Загружено писем: {loadedEmails.Count}");

		/*emlProcessor = new EmlProcessor();
		string emlFilePath = Application.dataPath + "/Emails/Test email title.eml";
		MailMessage message = emlProcessor.LoadEml(emlFilePath);

		if (message != null)
		{
			// Выводим тему и тело письма в консоль Unity
			Debug.Log("Subject: " + message.Subject);
			Debug.Log("From: " + message.From);
			Debug.Log("Body: " + message.Body);

			// Можно также обработать вложения, если нужно
			foreach (var attachment in message.Attachments)
			{
				Debug.Log("Attachment: " + attachment.Name);
				// Дополнительная логика для работы с вложениями
			}
		}
		else
		{
			Debug.LogError("Не удалось загрузить EML-файл.");
		}*/
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
