using TMPro;
using UnityEngine;

public class ResourceMonitor : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private float updateInterval = 0.5f;

	[SerializeField] private TMP_Text cpuText;
	[SerializeField] private TMP_Text networkText;
	[SerializeField] private TMP_Text memoryText;
	[SerializeField] private TMP_Text diskText;
	private float timer;

	public ResourceMonitorScriptableObj resources;

	private void Start()
	{
		resources.init();
	}

	private void Update()
	{
		timer += Time.deltaTime;

		if (timer >= updateInterval)
		{
			timer = 0f;
			cpuText.text = $"{resources.cpuResource(1,6):F1}%";
			networkText.text = $"{resources.networkResource(0,8):F1}%";
			memoryText.text = $"{resources.memoryResource(1, 10):F1}%";
			diskText.text = $"{resources.diskResource(1, 5):F1}%";
		}
	}
}
