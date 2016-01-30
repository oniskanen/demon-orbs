﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrbInfoController : MonoBehaviour {

	[SerializeField]
	private GameObject	orbPrefab;

	private static OrbInfoController _instance;

	public static OrbInfoController Instance
	{
		get
		{
			if (_instance == null)
			{
				Debug.LogWarning("No OrbInfoController instance!");
			}

			return _instance;
		}
	}

	// Use this for initialization
	void Start () {
		if (_instance == null)
		{
			_instance = this;
		}
		else
		{
			Debug.LogWarning("Multiple OrbInfoControllers in scene!");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ClearOrbs()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			GameObject child = transform.GetChild(i).gameObject;

			// TODO: Animate away
			Destroy(child);

		}
	}

	public void DrawNewOrbs(List<OrbType> orbs)
	{
		ClearOrbs();

		foreach (OrbType orb in orbs)
		{
			GameObject newOrb = Instantiate(orbPrefab);
			newOrb.transform.SetParent(this.transform);
			newOrb.transform.localScale = Vector3.one;

		}
	}


}