using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Landis.Controller;
using Landis.Interface;

namespace Landis
{
    public class Program
    {
        private readonly IBaseController ibc = new BaseController();

        public Program(IBaseController _ibc)
        {
            _ibc = ibc; 
        }

        static void Main(string[] args)
        {

            bool endApp = false;
            Console.WriteLine("Endpoint Manager\r");
            Console.WriteLine("------------------------\n");
            Console.Write("Choose an option below: \n");
            Console.WriteLine("\ti - Add new Endpoint");
            Console.WriteLine("\te - Edit an existing Endpoint");
            Console.WriteLine("\td - Delete an Endpoint");
            Console.WriteLine("\tl - List all registered Endpoints");
            Console.WriteLine("\tf - Find an Endpoint by 'Endpoint Serial Number'");
            Console.WriteLine("\tx - Exit application");

            while (!endApp)
            {

                string op = Console.ReadLine();
                switch (op)
                {
                    case "i":
                        AddEndPoint();
                        break;
                    case "e":
                        EditEndPoint();
                        break;
                    case "l":
                        bc.List();
                        break;
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
            }
        }

        private static void AddEndPoint()
        {
            Console.WriteLine("Enter serial number: \n");
            string serial = Console.ReadLine();
            Console.WriteLine("Enter Model id");
            int model_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter meter number");
            int meter_num = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Firmware Version");
            string firmware_ver = Console.ReadLine();
            Console.WriteLine("Enter switch state");
            int switch_est = int.Parse(Console.ReadLine());

            //Random rnd = new Random(1001);
            //Console.WriteLine("Enter serial number: \n");
            //string serial = Console.ReadLine();
            //while (string.IsNullOrEmpty(serial))
            //{
            //    Console.WriteLine("serial number cannot be empty: \n");
            //    serial = Console.ReadLine();
            //}
            //ep.serial_number = serial;

            //Console.WriteLine("Enter Model id");
            //var model_id = Console.ReadLine();
            //int m_id;
            //if (int.TryParse(model_id, out m_id))
            //    ep.model_id = m_id;

            //Console.WriteLine("Enter meter number");
            //var meter_num = Console.ReadLine();
            //int m_num;
            //if (int.TryParse(meter_num, out m_num))
            //    ep.meter_number = m_num;

            //Console.WriteLine("Enter Firmware Version");
            //string firmware_ver = Console.ReadLine();
            //while (string.IsNullOrEmpty(firmware_ver))
            //{
            //    Console.WriteLine("serial number cannot be empty: \n");
            //    firmware_ver = Console.ReadLine();
            //}
            //ep.firmware_version = firmware_ver;

            //Console.WriteLine("Enter switch state");
            //var switch_est = Console.ReadLine();
            //int sw_est;
            //if (int.TryParse(switch_est, out sw_est))
            //    ep.switch_state = sw_est;

            Endpoint ep = new Endpoint();

            ep.serial_number = serial;
            ep.ModelId = model_id;
            ep.meter_number = meter_num;
            ep.firmware_version = firmware_ver;
            ep.switch_state = switch_est;
            BaseController bc = new BaseController();
            bc.Insert(ep)
        }
    

        private static void EditEndPoint()
        {
            Console.WriteLine("Enter endpoint serial number: \n");
            string serial = Console.ReadLine();
            Console.WriteLine("Enter new switch state ( 0 - disconnected, 1 - connected, 2 - armed): \n");
            int state = int.Parse(Console.ReadLine());

            EditEndpoint(serial, state);

        }
    }
}
