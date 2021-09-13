using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ChildrenMaterialController : MonoBehaviour
{
    [SerializeField] private Material textureForChildren;
    private Renderer[] _materials;


    private void OnEnable()
    {
        _materials = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < _materials.Length; i++)
            _materials[i].material = textureForChildren;
    }
}
