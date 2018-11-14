﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NeatHook
{
    internal static class Dll
    {
        internal const string User32 = "user32.dll";
    }

    internal static class NativeMethods
    {
        /// <summary>
        /// Define a system-wide hot key.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that will receive WM_HOTKEY messages generated by the hot key. If
        /// this parameter is NULL, WM_HOTKEY messages are posted to the message queue of the calling
        /// thread and must be processed in the message loop.
        /// </param>
        /// <param name="id">
        /// The identifier of the hot key. If the hWnd parameter is NULL, then the hot key is
        /// associated with the current thread rather than with a particular window.
        /// </param>
        /// <param name="fsModifiers">
        /// The keys that must be pressed in combination with the key specified by the uVirtKey
        /// parameter in order to generate the WM_HOTKEY message. The fsModifiers parameter can be a
        /// combination of the following values. MOD_ALT 0x0001 MOD_CONTROL 0x0002 MOD_SHIFT 0x0004
        /// MOD_WIN 0x0008
        /// </param>
        /// <param name="vk">The virtual-key code of the hot key.</param>
        [DllImport(Dll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id,
            KeyModifiers fsModifiers, Keys vk);

        /// <summary>
        /// Frees a hot key previously registered by the calling thread.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window associated with the hot key to be freed. This parameter should be
        /// NULL if the hot key is not associated with a window.
        /// </param>
        /// <param name="id">The identifier of the hot key to be freed.</param>
        [DllImport(Dll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}