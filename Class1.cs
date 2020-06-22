using System;
using System.Runtime.InteropServices;

static class DeviceNotification
{
    // https://msdn.microsoft.com/en-us/library/aa363480(v=vs.85).aspx
    public const int DbtDeviceArrival = 0x8000; // system detected a new device        
    public const int DbtDeviceRemoveComplete = 0x8004; // device is gone     
    public const int DbtDevNodesChanged = 0x0007; //A device has been added to or removed from the system.

    public const int WmDevicechange = 0x0219; // device change event      
    private const int DbtDevtypDeviceinterface = 5;

    // https://msdn.microsoft.com/en-us/library/aa363431(v=vs.85).aspx

    private const int DEVICE_NOTIFY_WINDOW_HANDLE = 0;
    private const int DEVICE_NOTIFY_SERVICE_HANDLE = 1;
    private const int DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 4;

    private static readonly Guid GuidDevinterfaceUSBDevice = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED"); // USB devices
    private static readonly Guid GuidDevinterfaceDisplayAdapter = new Guid("5B45201D-F2F2-4F3B-85BB-30FF1F953599"); // Display devices
    private static readonly Guid GuidDevinterfaceMonitor = new Guid("E6F07B5F-EE97-4a90-B076-33F57BF4EAA7"); // Monitors

    private static IntPtr notificationHandle;

    private const bool filterSpecificDeviceTypes = false;

    /// <summary>
    /// Registers a window to receive notifications when devices are plugged or unplugged.
    /// </summary>
    /// <param name="windowHandle">Handle to the window receiving notifications.</param>
    /// <param name="filterSpecificDeviceTypes">true to filter to USB devices only, false to be notified for all devices.</param>
    public static void RegisterDeviceNotification(IntPtr windowHandle, bool filterSpecificDeviceTypes = filterSpecificDeviceTypes)
    {
        var dbi = new DevBroadcastDeviceinterface
        {
            DeviceType = DbtDevtypDeviceinterface,
            Reserved = 0,
            //    ClassGuid = GuidDevinterfaceUSBDevice,
            ClassGuid = GuidDevinterfaceMonitor,
            Name = 0
        };

        dbi.Size = Marshal.SizeOf(dbi);
        IntPtr buffer = Marshal.AllocHGlobal(dbi.Size);
        Marshal.StructureToPtr(dbi, buffer, true);

        notificationHandle = RegisterDeviceNotification(windowHandle, buffer, filterSpecificDeviceTypes ? DEVICE_NOTIFY_WINDOW_HANDLE : DEVICE_NOTIFY_ALL_INTERFACE_CLASSES);
    }

    /// <summary>
    /// Unregisters the window for device notifications
    /// </summary>
    public static void UnregisterDeviceNotification()
    {
        UnregisterDeviceNotification(notificationHandle);
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr RegisterDeviceNotification(IntPtr recipient, IntPtr notificationFilter, int flags);

    [DllImport("user32.dll")]
    private static extern bool UnregisterDeviceNotification(IntPtr handle);

    [StructLayout(LayoutKind.Sequential)]
    private struct DevBroadcastDeviceinterface
    {
        internal int Size;
        internal int DeviceType;
        internal int Reserved;
        internal Guid ClassGuid;
        internal short Name;
    }
}