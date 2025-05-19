using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class TransparentWindow : MonoBehaviour
{
    [DllImport("user32.dll")]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("TransparentWindow.dll")]
    private static extern void SetTransparent(IntPtr hwnd);

    [DllImport("TransparentWindow.dll")]
    private static extern void SetRoundedCorners(IntPtr hwnd, int radius);

    void Start()
    {
        // Unity window title = Application.productName
        IntPtr hwnd = FindWindow(null, Application.productName);
        if (hwnd != IntPtr.Zero)
        {
            SetTransparent(hwnd);
            SetRoundedCorners(hwnd, 30); // Adjust corner radius
        }
        else
        {
            Debug.LogError("Failed to find Unity window.");
        }
    }
}
