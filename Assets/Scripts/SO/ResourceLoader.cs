using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader
{
    public Theme GetTheme(string themeName)
    {
        return Resources.Load<Theme>(themeName);
    }
}
