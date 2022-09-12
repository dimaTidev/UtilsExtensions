using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Transform_Extensions
{
    /// <summary>
    /// from worldRotation to LocalRotation
    /// </summary>
    /// <returns>It returns localRotation!!! related to the parent of this</returns>
    // public static Quaternion InverseTransformRotation(this Transform pivot, Quaternion worldRotation) => Quaternion.Inverse(pivot.parent ? pivot.parent.rotation : Quaternion.identity) * worldRotation;
    public static Quaternion InverseTransformRotation(this Transform pivot, Quaternion worldRotation) => Quaternion.Inverse(pivot.rotation) * worldRotation;

    /// <summary>
    /// from localRotation to worldRotation 
    /// </summary>
    public static Quaternion TransformRotation(this Transform pivot, Quaternion localRotation) => pivot.rotation * localRotation;

}
