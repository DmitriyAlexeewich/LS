using UnityEditor;
using UnityEngine;
public class CustomListItemNameAttribute : PropertyAttribute
{
    public readonly string Varname;

    public CustomListItemNameAttribute(string varname)
    {
        Varname = varname;
    }
}