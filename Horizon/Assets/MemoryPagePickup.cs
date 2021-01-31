using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPagePickup : MonoBehaviour
{
    public GameObject UIObject;
    public GameObject Hud;

    Pickup m_Pickup;

    // Start is called before the first frame update
    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, HealthPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnPicked(PlayerCharacterController player)
    {
        Hud.SetActive(false);
        UIObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        m_Pickup.PlayPickupFeedback();
        Destroy(gameObject);
    }
}
