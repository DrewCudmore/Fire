using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // view bob
    public Vector3 restPosition;
    public float transitionSpeed = 20f;
    public float bobSpeed = 4.8f;
    public float bobAmount = 0.05f;

    float timer = Mathf.PI / 2;
    Vector3 camPos;

    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    void Awake() { camPos = transform.localPosition; }
    void Start() { Cursor.lockState = CursorLockMode.Locked; }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        HeadBob();
    }

    void HeadBob()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 ||
            Input.GetAxisRaw("Vertical") != 0)
        {
            timer += bobSpeed * Time.deltaTime;

            Vector3 newPos = new Vector3(
                Mathf.Cos(timer) * bobAmount,
                restPosition.y + Mathf.Abs((Mathf.Sin(timer) * bobAmount)),
                restPosition.z);
            camPos = newPos;
        }
        else
        {
            timer = Mathf.PI / 2;

            Vector3 newPos =
                new Vector3(Mathf.Lerp(camPos.x, restPosition.x,
                                       transitionSpeed * Time.deltaTime),
                            Mathf.Lerp(camPos.y, restPosition.y,
                                       transitionSpeed * Time.deltaTime),
                            Mathf.Lerp(camPos.z, restPosition.z,
                                       transitionSpeed * Time.deltaTime));
            camPos = newPos;
            // Vector3 newPos = new Vector3(Mathf.Lerp(camPos.x, restPosition.x,
            // transitionSpeed * Time.deltaTime), Mathf.Lerp((camPos.y,
            // restPosition.y, transitionSpeed * Time.deltaTime), Mathf.Lerp(camPos.z,
            // restPosition.z, transitionSpeed * Time.deltaTime)));
        }

        if (timer > Mathf.PI * 2)
        {
            timer = 0;
        }
    }
}
