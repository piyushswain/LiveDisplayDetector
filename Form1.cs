using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace LiveDeviceDector2
{
    public partial class Form1 : Form
    {

        private const int WM_DEVICECHANGE = 0x219;
        private const int DBT_DEVICEARRIVAL = 0X8000;
        private const int DBT_DEVICEREMOVECOMPLETE = 0X8004;
        private const int DBT_CONFIGCHANGED = 0X0018;
        private const int DBT_DEVICEQUERYREMOVEFAILED = 0X8002;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == DeviceNotification.WmDevicechange)
            {
                //Console.WriteLine(m.LParam);
                //Console.WriteLine(m);
                //Console.WriteLine("HERE");
                //Console.WriteLine(m.WParam);

                switch ((int)m.WParam)
                {
                    case DeviceNotification.DbtDeviceRemoveComplete:
                        messageListBox.Items.Add("Device Removed"); // this is where you do your magic
                        break;
                    case DeviceNotification.DbtDeviceArrival:
                        messageListBox.Items.Add("Device added"); // this is where you do your magic
                        break;
                }
                string[] message = null;
                Thread t = new Thread(new ThreadStart(() =>
                {
                    message = getDisplays();
                }));

                t.Start();
                t.Join();
                messageListBox.Items.Add(message[0]);
                messageListBox.Items.Add(message[1]);
            }
        }

        private string[] getDisplays()
        {
            var displays = DisplayDevice.GetDisplayDevices();
            string allDisplays = "";
            string liveDisplays = "LIVE DISPLAYS:: ";
            ushort[] runningModes = { 3, 4, 7, 13, 14, 15, 16, 17 };
            foreach (var device in displays)
            {
                if (runningModes.Contains(device.Availability))
                {
                    liveDisplays += $"PNP Device ID: { device.PnpDeviceID}, Availability: { device.Availability} | ";
                }
                allDisplays += $"PNP Device ID: {device.PnpDeviceID}, Availability: {device.Availability} | \n";
                Console.WriteLine("Device ID: {0}, PNP Device ID: {1}, Description: {2}, Name: {3}, MonitorType: {4}, Availability: {5}",
                    device.DeviceID, device.PnpDeviceID, device.Description, device.Name, device.MonitorType, device.Availability);
            }
            return new string[] { allDisplays, liveDisplays };
        }

        public Form1()
        {
            InitializeComponent();
            DeviceNotification.RegisterDeviceNotification(this.Handle);
            string[] message = null;
            Thread t = new Thread(new ThreadStart(() =>
            {
                message = getDisplays();
            }));

            t.Start();
            t.Join();
            messageListBox.Items.Add(message[0]);
            messageListBox.Items.Add(message[1]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void clearListBoxButton_Click_1(object sender, EventArgs e)
        {
            messageListBox.Items.Clear();
        }
    }
}
