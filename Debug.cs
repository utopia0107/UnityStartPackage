//#if UNITY_EDITOR 
//#define DEBUG
//#endif

using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngineInternal;


/// 
/// It overrides UnityEngine.Debug to mute debug messages completely on a platform-specific basis.
/// 
/// Putting this inside of 'Plugins' foloder is ok.
/// 
/// Important:
///     Other preprocessor directives than 'UNITY_EDITOR' does not correctly work.
/// 
/// Note:
///     [Conditional] attribute indicates to compilers that a method call or attribute should be 
///     ignored unless a specified conditional compilation symbol is defined.
/// 
/// See Also: 
///     http://msdn.microsoft.com/en-us/library/system.diagnostics.conditionalattribute.aspx
/// 
/// 2012.11. @kimsama
///
using System.Diagnostics;
public static class Debug 
{
    public static bool isDebugBuild
    {
	get { return UnityEngine.Debug.isDebugBuild; }
    }

    [Conditional("UNITY_EDITOR"),Conditional("DEBUG")]
    public static void Log (object message)
    {   
        UnityEngine.Debug.Log (message);
    }

    [Conditional("UNITY_EDITOR"),Conditional("DEBUG")]
    public static void Log (object message, UnityEngine.Object context)
    {   
        UnityEngine.Debug.Log (message, context);
    }
		
    [Conditional("UNITY_EDITOR"),Conditional("DEBUG")]
    public static void LogError (object message)
    {   
        UnityEngine.Debug.LogError (message);
    }

    [Conditional("UNITY_EDITOR"),Conditional("DEBUG")]	
    public static void LogError (object message, UnityEngine.Object context)
    {   
        UnityEngine.Debug.LogError (message, context);
    }
 
    [Conditional("UNITY_EDITOR"),Conditional("DEBUG")]
    public static void LogWarning (object message)
    {   
        UnityEngine.Debug.LogWarning (message.ToString ());
    }

    [Conditional("UNITY_EDITOR"),Conditional("DEBUG")] 
    public static void LogWarning (object message, UnityEngine.Object context)
    {   
        UnityEngine.Debug.LogWarning (message.ToString (), context);
    }

    [Conditional("UNITY_EDITOR"),Conditional("DEBUG")] 
    public static void DrawLine(Vector3 start, Vector3 end, Color color = default(Color), float duration = 0.0f, bool depthTest = true)
    {
 	UnityEngine.Debug.DrawLine(start, end, color, duration, depthTest);
    } 
	
    [Conditional("UNITY_EDITOR"),Conditional("DEBUG")]
    public static void DrawRay(Vector3 start, Vector3 dir, Color color = default(Color), float duration = 0.0f, bool depthTest = true)
    {
	UnityEngine.Debug.DrawRay(start, dir, color, duration, depthTest);
    }
 	
    [Conditional("UNITY_EDITOR"),Conditional("DEBUG")]
    public static void Assert(bool condition, object message)
    {
	    if (!condition) throw new Exception();
        Log(message);
    }
    [Conditional("UNITY_EDITOR"),Conditional("DEBUG")]	
    public static void LogErrorFormat (string format, params object[] args)
    {   
        UnityEngine.Debug.LogErrorFormat(format, args);
    }
    [Conditional("UNITY_EDITOR"),Conditional("DEBUG")]	
    public static void LogFormat (string format, params object[] args)
    {   
        UnityEngine.Debug.LogFormat(format, args);
    }
    [Conditional("UNITY_EDITOR"),Conditional("DEBUG")]	
    public static void LogException (Exception exception)
    {
        UnityEngine.Debug.LogException(exception);
    }
}