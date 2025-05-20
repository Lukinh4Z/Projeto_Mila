using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GlobalConverters
{
#if UNITY_EDITOR
    [InitializeOnLoadMethod]
#else
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeOnLoadType.SubsystemRegistration)]
#endif
    public static void RegisterConverters()
    {
        RegisterConverter<bool, StyleColor>("BoolToColor", BoolToColor);
    }

    private static StyleColor BoolToColor(ref bool value)
    {
        if (value)
        {
            return Color.red;
        }
        else
        {
            {  return Color.yellow; }
        }
    }

    #region helper
    private static void RegisterConverter<TInput, TOutput>(
        string groupName,
        Unity.Properties.TypeConverter<TInput, TOutput> converterFunc)
    {
        var group = new ConverterGroup(groupName);
        group.AddConverter<TInput, TOutput>(converterFunc);
        ConverterGroups.RegisterConverterGroup(group);
    }
    #endregion
}
