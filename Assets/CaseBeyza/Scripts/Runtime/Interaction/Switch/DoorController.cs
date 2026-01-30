using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator m_DoorAnimator;

    private bool m_IsOpen;

    public void ToggleDoor()
    {
        m_IsOpen = !m_IsOpen;

        if (m_DoorAnimator != null)
        {
            m_DoorAnimator.SetBool("Open", m_IsOpen);
        }
    }
}
