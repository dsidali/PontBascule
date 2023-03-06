using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PontBascule.Business
{
    public class BusinessOperation
    {

        public int Peser(string portName)
        {

            try
            {
                System.IO.Ports.SerialPort serialPort1;
                serialPort1 = new System.IO.Ports.SerialPort();
                serialPort1.Close();
                serialPort1.PortName = portName;
                serialPort1.BaudRate = 9600;
                serialPort1.Parity = Parity.None;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.ReceivedBytesThreshold = 1;
                serialPort1.DtrEnable = true;
                serialPort1.RtsEnable = true;
                serialPort1.Open();
                int reading = serialPort1.ReadByte();
                var poids = int.Parse(serialPort1.ReadExisting());
                serialPort1.Close();
                serialPort1.Dispose();

                return poids;

            }
            catch (Exception e)
            {
                //    Console.WriteLine(e);
                //throw;
                //MessageBox.Show(e.Message);
                //poidsValueLabel.Text = "0";
                // erreur = e.Message;

                throw;
            }
        }
    }
}
