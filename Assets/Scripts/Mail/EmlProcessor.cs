using Aspose.Email;
using MimeKit;
using System;
using UnityEngine;

public class EmlProcessor
{
	public MimeMessage LoadEml(string filePath)
	{
		try
		{
			MimeMessage message = MimeMessage.Load(filePath);
			return message;
		}
		catch (Exception ex)
		{
			Debug.LogError($"Ошибка загрузки EML: {ex.Message}");
			return null;
		}
	}
}
