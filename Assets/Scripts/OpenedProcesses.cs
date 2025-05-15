using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public struct Resource
{
	GameObject process;
	int cpuLoad;
    int networkLoad;
    int memoryLoad;
    int diskLoad;

	public Resource(GameObject process, 
		int cpuLoad, 
		int networkLoad, 
		int memoryLoad,
		int diskLoad)
	{
		this.process = process;
		this.cpuLoad = cpuLoad;
		this.networkLoad = networkLoad;
		this.memoryLoad = memoryLoad;
		this.diskLoad = diskLoad;
	}

	public string GetName() { return process.name;}
}

public class OpenedProcesses : MonoBehaviour
{
    public RawImage backgroundImage;
	ObservableCollection<Resource> processes = new ObservableCollection<Resource>();
    [SerializeField] List<string> processesView = new List<string>();

	private void Start()
	{
		
	}

	public void AddProcess(Resource resource)
	{
		processes.Add(resource);
	}

	public void RmProcess(Resource resource)
	{
		processes.Remove(resource);
	}

	private void Update()
	{
		
		processes.CollectionChanged += (sender, e) =>
		{
			if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
			{
				foreach (Resource removedItem in e.OldItems)
				{
					processesView.Remove(removedItem.GetName()); // Удаляем из Б
				}
			}
			if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
			{
				foreach (Resource resource in processes)
				{
					if (!processesView.Contains(resource.GetName()))
						processesView.Add(resource.GetName());
				}
			}
		};
	}
}
