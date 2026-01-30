using UnityEngine;
using UnityEngine.UI;

public class SwitchInteractable : MonoBehaviour
{
    [SerializeField] private DoorController m_Door;
    [SerializeField] private GameObject m_YPressText;

    private bool m_PlayerInside;

    void Start()
    {
        if (m_YPressText != null)
            m_YPressText.SetActive(false);
    }

    void Update()
    {
        if (!m_PlayerInside) return;

        if (Input.GetKeyDown(KeyCode.Y))
        {
            m_Door.ToggleDoor();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_PlayerInside = true;

            if (m_YPressText != null)
                m_YPressText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_PlayerInside = false;

            if (m_YPressText != null)
                m_YPressText.SetActive(false);
        }
    }
}
