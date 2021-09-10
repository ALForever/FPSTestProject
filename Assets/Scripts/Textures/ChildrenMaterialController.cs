using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ChildrenMaterialController : MonoBehaviour
{
    [SerializeField] private Material textureForChildren;
    private Renderer[] materials;


    private void OnEnable()
    {
        materials = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < materials.Length; i++)
            materials[i].material = textureForChildren;
    }
}
