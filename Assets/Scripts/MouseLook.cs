using UnityEngine;

[AddComponentMenu("Control Script/Mouse Look")]

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY,
        MouseX,
        MouseY
    }
    public RotationAxes axes;
    public float sensitivityHor = 9f;
    public float sensitivityVert = 9f;

    public float minimumVert = -45f;
    public float maximumVert = 45f;

    private float _rotationX = 0;
    private float _rotationY = 0;
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }
    void Update()
    {
        switch (axes)
        {
            case RotationAxes.MouseX:
                RotationMouseX();
                break;
            case RotationAxes.MouseY:
                RotationMouseY();
                break;
            case RotationAxes.MouseXAndY:
                RotationMouseX();
                RotationMouseY();
                break;
        }
    }

    private void RotationMouseX()
    {
        _rotationY += Input.GetAxis("Mouse X") * sensitivityHor;
        transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
    }

    private void RotationMouseY()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
    }
}
