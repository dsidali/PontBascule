using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace PontBascule.Data
{
    public class BusinessLayer
    {
        public BusinessLayer() { }
        public BusinessLayer(int id) { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Peser()
        {
            int poids = 0;
            try
            {
                System.IO.Ports.SerialPort serialPort1;
                serialPort1 = new System.IO.Ports.SerialPort();
                serialPort1.Close();
                serialPort1.PortName = "COM3";
                serialPort1.BaudRate = 9600;
                serialPort1.Parity = Parity.None;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.ReceivedBytesThreshold = 1;
                serialPort1.DtrEnable = true;
                serialPort1.RtsEnable = true;
                serialPort1.Open();

                Thread.Sleep(5000);
                int reading = serialPort1.ReadByte();
                poids = int.Parse(serialPort1.ReadExisting());
                serialPort1.Close();
                serialPort1.Dispose();

                
            }
            catch (Exception e)
            {
                //    Console.WriteLine(e);
                //throw;
                //MessageBox.Show(e.Message);
                //poidsValueLabel.Text = "0";
               // erreur = e.Message;
               poids = 0;
            }

            return poids;
        }
    }
}
