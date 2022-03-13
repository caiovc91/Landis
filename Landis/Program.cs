using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Landis.Controller;
using Landis.Interface;
using Landis.Models;

namespace Landis
{
    public class Program
    {


        public static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            ui.Run();

        }





    }
    public class UserInterface
    {
        private readonly IBaseController _ibc = new BaseController();

        public UserInterface(IBaseController ibc)
        {
            _ibc = ibc;
        }

        public UserInterface()
        {
        }

        public void Run()
        {
            bool endApp = false;
            RenderMenu();

            while (!endApp)
            {

                string op = Console.ReadLine();
                switch (op)
                {
                    case "i":
                        AddEndPoint();
                        RenderMenu();
                        break;
                    case "e":
                        EditSwitchState();
                        RenderMenu();
                        break;
                    case "l":
                        _ibc.List();
                        RenderMenu();
                        break;
                    case "d":
                        DeleteEndpoint();
                        RenderMenu();
                        break;
                    case "f":
                        FindEndpoint();
                        RenderMenu();
                        break;
                    case "c":
                        Console.Clear();
                        RenderMenu();
                        break;
                    case "x":
                        ExitApplication();
                        break;
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
            }

        }
        private void ExitApplication()
        {
            Console.WriteLine("Do you wanna close the application? \n y - yes \n any other key - no");
            var exit = Console.Read();
            if (exit == 'y' )
            {
                Environment.Exit(0);
            }
        }
        private void RenderMenu()
        {
            Console.WriteLine("Endpoint Manager\r");
            Console.WriteLine("------------------------\n");
            Console.Write("Choose an option below: \n");
            Console.WriteLine("\ti - Add new Endpoint");
            Console.WriteLine("\te - Edit an existing Endpoint");
            Console.WriteLine("\td - Delete an Endpoint");
            Console.WriteLine("\tl - List all registered Endpoints");
            Console.WriteLine("\tf - Find an Endpoint by 'Endpoint Serial Number'");
            Console.WriteLine("\tc - Clear Screen");
            Console.WriteLine("\tx - Exit application");
        }
        private void AddEndPoint()
        {
            bool validation = false;
            Endpoint ep = new Endpoint();

            string serial = "";
            while (!validation)
            {
                Console.WriteLine("Enter serial number: \n");
                serial = Console.ReadLine();
                if (_ibc.ValidateExistantSerial(serial))
                {
                    Console.WriteLine("Serial number already exists!");
                }
                else if (string.IsNullOrEmpty(serial))
                {
                    Console.WriteLine("serial number cannot be empty: \n");
                }
                else
                {
                    validation = true;
                }
            }
            ep.serial_number = serial;

            var model_id = "";
            int m_id;
            validation = false;
            while (!validation)
            {
                Console.WriteLine("Enter Model id");
                Console.WriteLine("Available IDs : \n \t 16 - NSX1P2W \t 17 - NSX1P3W \t 18 - NSX2P3W \t 19 - NSX3P4W");
                model_id = Console.ReadLine();
                if (!int.TryParse(model_id, out m_id))
                {
                    Console.WriteLine("Model id must be an integer number \n Please insert a valid model id");

                }
                else if (new MeterModel(m_id).ModelName == "INVALID")
                {
                    Console.WriteLine("Invalid Id number!");
                }
                else
                {
                    validation = true;
                }
            }
            ep.MeterModel = new MeterModel(int.Parse(model_id));

            Console.WriteLine("Enter meter number");
            var meter_num = Console.ReadLine();
            int m_num;
            while (!int.TryParse(meter_num, out m_num))
            {
                Console.WriteLine("meter number must be an integer number \n Please insert a valid number");
                meter_num = Console.ReadLine();
            }
            ep.meter_number = m_num;

            Console.WriteLine("Enter Firmware Version");
            string firmware_ver = Console.ReadLine();
            while (string.IsNullOrEmpty(firmware_ver))
            {
                Console.WriteLine("firmware version cannot be empty. \n Insert a valid firmware version");
                firmware_ver = Console.ReadLine();
            }
            ep.firmware_version = firmware_ver;

            var switch_est = "";
            int sw_est;
            validation = false;
            while (!validation)
            {
                Console.WriteLine("Enter switch state ( 0 - disconnected, 1 - connected, 2 - armed): \n");
                switch_est = Console.ReadLine();
                if (!int.TryParse(switch_est, out sw_est))
                {
                    Console.WriteLine("switch state must be a number");
                }
                else if (sw_est < 0 || sw_est > 2)
                {
                    Console.WriteLine("Enter valid switch state ( 0 - disconnected, 1 - connected, 2 - armed): \n");
                }
                else
                {
                    validation = true;
                }
            }
            ep.switch_state = int.Parse(switch_est);

            _ibc.Insert(ep);

        }
        private void EditSwitchState()
        {
            Console.WriteLine("Enter endpoint serial number: \n");
            string serial = Console.ReadLine();
            _ibc.ValidateExistantSerial(serial);
            while (!_ibc.ValidateExistantSerial(serial))
            {
                Console.WriteLine("Invalid serial number, please enter a valid one:");
                serial = Console.ReadLine();
            }
            Console.WriteLine("Enter new switch state ( 0 - disconnected, 1 - connected, 2 - armed): \n");
            int state = int.Parse(Console.ReadLine());

            _ibc.Edit(serial, state);
            Console.Clear();
            RenderMenu();
        }
        private void DeleteEndpoint()
        {
            Console.WriteLine("Enter endpoint serial number: \n");
            string serial = Console.ReadLine();
            _ibc.ValidateExistantSerial(serial);
            while (!_ibc.ValidateExistantSerial(serial))
            {
                Console.WriteLine("Invalid serial number, please enter a valid one:");
                serial = Console.ReadLine();
            }
            _ibc.Delete(serial);
        }
        private void FindEndpoint()
        {
            Console.WriteLine("Enter endpoint serial number: \n");
            string serial = Console.ReadLine();
            _ibc.ValidateExistantSerial(serial);
            while (!_ibc.ValidateExistantSerial(serial))
            {
                Console.WriteLine("Invalid serial number, please enter a valid one:");
                serial = Console.ReadLine();
            }
            _ibc.Find(serial);
        }
    }
}
