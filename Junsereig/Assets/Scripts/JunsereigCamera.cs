using UnityEngine;
using System.Collections;

public class JunsereigCamera : MonoBehaviour
{
    public float Y_ANGLE_MIN = 20.0f;
    public float Y_ANGLE_MAX = 50.0f;

    public Transform cameraZoomPoint;

    public Transform lookAt;
    public Transform camTranform;
    public AdjustCameraFocus cameraFocus;

    public GameObject Player;

    public static bool PassiveMode;

    private static AdjustCameraFocus focusInstance;

    public static bool canZoom = true;

    private bool Look;

    public bool updateCameraLocation = true;

    public float currentX = 0.0f;
    public float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    public float cameraDistanceMax = 20f;
    public float cameraDistanceMin = 5f;
    public float cameraDistance = 10f;
    public float scrollSpeed = 1.0f;

    public bool ResetCamera = false;
    public float ResetCameraSpeed;

    private void Awake()
    {
        focusInstance = cameraFocus;
        ResetCamera = false;
        camTranform = transform;

        ChangeCameraMode(PassiveMode);
    }

    public static void ChangeCameraMode(bool mode)
    {
        if (mode == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PassiveMode = true;
            focusInstance.Crosshair.SetActive(false);
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.Locked;
            PassiveMode = false;
            focusInstance.Crosshair.SetActive(true);
        }
        UpdateMode.ChangeUI(PassiveMode);
        UIModeManager.CameraMode = PassiveMode;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "CameraTarget")
        {
            if (other.isTrigger == false)
            {
                cameraDistance -= 0.1f;
            }
        }
    }

    private void Update()
    {
        if (canZoom)
        {
            cameraDistance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);
        }

        if (Look)
        {
            currentX += Input.GetAxis("Mouse X");
            currentY -= Input.GetAxis("Mouse Y");

            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (PassiveMode == false)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                PassiveMode = true;
                UIModeManager.CameraMode = true;
                cameraFocus.Crosshair.SetActive(false);
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.lockState = CursorLockMode.Locked;
                PassiveMode = false;
                UIModeManager.CameraMode = false;
                cameraFocus.Crosshair.SetActive(true);
            }
            UpdateMode.ChangeUI(PassiveMode);
        }

        if (Input.GetButtonDown("FocusCamera"))
        {
            if (ResetCamera == false)
            {
                ResetCamera = true;
            }
        }

        //Return camera to face North over time;
        if(ResetCamera == true)
        {
            currentX = Mathf.RoundToInt(currentX);
            currentY = Mathf.RoundToInt(currentY);

            currentX = 3;
            currentY = 20;

            if (currentX == 3 && currentY == 20)
            {
                ResetCamera = false;
            }
        }


        if (PassiveMode)
        {
            PlayerCameraLook.MouseLook = false;
            Look = false;
        }
        else if (!PassiveMode)
        {
            PlayerCameraLook.MouseLook = true;
            Look = true;
        }

        if (PassiveMode)
        {
            if (Input.GetMouseButton(2))
            {
                currentX += Input.GetAxis("Mouse X") * sensitivityX;
                currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

                currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
            }
        }
    }

    private void LateUpdate()
    {
        if (updateCameraLocation == true)
        {
            Vector3 dir = new Vector3(0, 0, -cameraDistance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            camTranform.position = lookAt.position + rotation * dir;
            camTranform.LookAt(lookAt.position);
        }
    }
}
