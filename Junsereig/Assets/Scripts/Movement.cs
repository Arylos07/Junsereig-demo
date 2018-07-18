using UnityEngine;


//Simple script. For the scope of this work, not much more is needed
public class Movement : MonoBehaviour
{
    public Transform m_Cam;                  
    private Vector3 m_CamForward;             
    private Vector3 move;
    private bool m_Jump;
    float m_TurnAmount;
    float m_ForwardAmount;
    Vector3 m_GroundNormal;

    public float walkSpeedMult = 0.5f;
    public float speedMult = 1;

    private void FixedUpdate()
    {
        // read inputs
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // calculate move direction to pass to character
        if (m_Cam != null)
        {
            // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            move = v * m_CamForward + h * m_Cam.right;

            transform.Translate(move * walkSpeedMult);
        }
    }
}