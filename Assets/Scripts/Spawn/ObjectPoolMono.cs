using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolMono<T> where T : MonoBehaviour
{
    public T prefab { get; }
    public bool autoExpand { get; set; }
    public Transform container { get; }

    private List<T> _pool;

    public ObjectPoolMono(T prefab, int count, Transform container, bool isActiveByDefault = false)
    {
        this.prefab = prefab;
        this.container = container;

        CreatePool(count, isActiveByDefault);
    }

    private void CreatePool(int count, bool isActiveByDefault)
    {
        _pool = new List<T>();
        for (int i = 0; i < count; i++)
        {
            CreateObject(isActiveByDefault);
        }
    }

    private T CreateObject(bool isActiveByDefault)
    {
        T createdObject = UnityEngine.Object.Instantiate(prefab, container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T element)
    {
        if (_pool != null)
            foreach (T mono in _pool)
            {
                if (!mono.gameObject.activeInHierarchy)
                {
                    element = mono;
                    mono.gameObject.SetActive(true);
                    return true;
                }
            }
        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out T element))
            return element;
        if (autoExpand)
            return CreateObject(true);
        throw new Exception($"There is no free elements in pool of type {typeof(T)}");
    }
    public List<T> GetAllActiveElemets()
    {
        if(_pool != null)
        {
            List<T> activeElements = new List<T>();
            foreach( T mono in _pool)
            {
                if (mono.gameObject.activeInHierarchy)
                {
                    activeElements.Add(mono);                    
                }
            }
            return activeElements;

        }
        return null;
    }    
}
