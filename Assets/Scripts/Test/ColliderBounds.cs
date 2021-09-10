using UnityEngine;

public class ColliderBounds : MonoBehaviour
{
    Transform m_Transform;
    Collider m_Collider;
    Vector3 m_Center;
    Vector3 m_Size, m_Min, m_Max, m_Extents;

    void Start()
    {
        //Fetch the Collider from the GameObject
        m_Transform = GetComponent<Transform>();
        m_Collider = GetComponent<Collider>();
        //Fetch the center of the Collider volume
        m_Center = m_Collider.bounds.center;
        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size;
        //Fetch the minimum and maximum bounds of the Collider volume
        m_Min = m_Collider.bounds.min;
        m_Max = m_Collider.bounds.max;
        m_Extents = m_Collider.bounds.extents;
        //Output this data into the console
        OutputData();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            OutputData();
    }

    void OutputData()
    {
        //Output to the console the center and size of the Collider volume
        Debug.Log("Collider Center : " + m_Center);
        Debug.Log("Collider Size : " + m_Size);
        Debug.Log("Collider bound Minimum : " + m_Min);
        Debug.Log("Collider bound Maximum : " + m_Max);
        Debug.Log("Collider bound Extents : " + m_Extents);
        Debug.Log("WORLD Collider Center : " + m_Transform.TransformPoint(m_Center));
        Debug.Log("WORLD Collider Size : " + m_Transform.TransformPoint(m_Size));
        Debug.Log("WORLD Collider bound Minimum : " + m_Transform.TransformPoint(m_Min));
        Debug.Log("WORLD Collider bound Maximum : " + m_Transform.TransformPoint(m_Max));
        Debug.Log("WORLD Collider bound Extents : " + m_Transform.TransformPoint(m_Extents));
    }
}
