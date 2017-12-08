using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour {
	
	
	public List<Item> inventory = new List<Item>();
	
	public GameObject[] inventoryObjects;
	private Button closeInvButton;

	void hideInventoryClicked() {
		foreach (GameObject i in inventoryObjects)
		{
			i.SetActive(false);
			Time.timeScale = 1;
		}
	}
	//shows objects with InventoryWindow tag
	public void showInventory()
	{
		foreach (GameObject i in inventoryObjects)
		{
			i.SetActive(true);
		}
	}
	//hides objects with InventoryWindow tag
	public void hideInventory()
	{
		foreach (GameObject i in inventoryObjects)
		{
			i.SetActive(false);
		}
	}
	void Start () {
		inventoryObjects = GameObject.FindGameObjectsWithTag("InventoryWindow");
		closeInvButton = (Button)GameObject.Find("CloseInvButton").GetComponent<Button>();
		closeInvButton.onClick.AddListener(hideInventoryClicked);
		hideInventory();

	}
		
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showInventory();
			}
			else if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
				hideInventory();
			}
		}
			
	}
}