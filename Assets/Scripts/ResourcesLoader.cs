using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourcesLoader
{
    public static GameObject LoadPrefab(ResourcesPath path)
    {
        return Resources.Load<GameObject>(path.PathResources);
    }
}
