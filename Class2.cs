using System;
using System.Collections.Generic;
using System.Management;

static class DisplayDevice
{
    public static List<DisplayDeviceInfo> GetDisplayDevices()
    {
        List<DisplayDeviceInfo> devices = new List<DisplayDeviceInfo>();

        ManagementObjectCollection collection;
        using (var searcher = new ManagementObjectSearcher(@"Select * from Win32_PnPEntity where PNPClass = 'Monitor'"))
            collection = searcher.Get();

        foreach (var device in collection)
        {
            devices.Add(new DisplayDeviceInfo(
            (string)device.GetPropertyValue("DeviceID"),
            (string)device.GetPropertyValue("Name")
            ));
        }

        collection.Dispose();
        return devices;
    }
}

class DisplayDeviceInfo
{
    public DisplayDeviceInfo(string deviceID, string name)
    {
        this.DeviceID = deviceID;
        //this.PnpDeviceID = pnpDeviceID;
        //this.Description = description;
        this.Name = name;
        //this.Availability = availability;
    }
    public string DeviceID { get; private set; }
    //public string PnpDeviceID { get; private set; }
    //public string Description { get; private set; }
    public string Name { get; private set; }
    //public ushort Availability { get; private set; }
}
