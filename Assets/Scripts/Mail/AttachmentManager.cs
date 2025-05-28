using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttachmentManager : MonoBehaviour
{
    public GameObject attachmentPrefab;
    public Transform appContext;

    public List<string> items = new List<string>() {"12312", "534523", "virus", "abababab", "secret file", "virus", "Virus"};
	public List<string> names = new List<string>() { "fafaf", "sssss", "noVirus", "asda", "secret file", "cool file", "cheats" };


	System.Random random = new System.Random();

	public void Start()
	{
		appContext = GameObject.Find("Desktop").transform;
	}

	public void SaveAttachment()
    {
        GameObject attch = Instantiate(attachmentPrefab, appContext);

        var attchInfo = attch.GetComponent<DraggableAttachment>();
        attchInfo.itemInfo = items[random.Next(items.Count)];

        var attchText = attch.transform.Find("Text").GetComponent<TMP_Text>();
		attchText.text = items[random.Next(items.Count)];
	}
}
