using System;
using UnityEngine;

/// <summary>
/// Custom Attribute. 
/// Being used to check if the fields with this attribute have reference.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public class NotNullable : PropertyAttribute
{

}
