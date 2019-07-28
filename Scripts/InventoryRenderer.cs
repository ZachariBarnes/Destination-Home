using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryRenderer : MonoBehaviour {

    public GameObject itemImage;

	public void UpdateInventory(List<GameObject> inventory)
    {
        // Destroy all old images
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        // Create new images in UI
        int itemNumber = 0;
        foreach(GameObject item in inventory)
        {
            itemImage.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            itemImage.GetComponent<RectTransform>().SetPositionAndRotation(new Vector3(((40 * itemNumber)), -20), new Quaternion());
            Instantiate(itemImage, this.gameObject.transform);

            itemNumber += 1;
        }
    }
}
