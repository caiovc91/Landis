using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Landis.Models;
using Landis.Interface;

namespace Landis.Controller
{
    public class BaseController : IBaseController
    {
        public  List<EndpointModel> endpointModels = new List<EndpointModel>
        {
            new EndpointModel{ModelId = 16, ModelName = "NSX1P2W"},
            new EndpointModel{ModelId = 17, ModelName = "NSX1P3W"},
            new EndpointModel{ModelId = 18, ModelName = "NSX2P3W"},
            new EndpointModel{ModelId = 19, ModelName = "NSX3P4W"},
        };
        public  List<Endpoint> endpoints = new List<Endpoint>
        {
            new Endpoint { serial_number = "1", ModelId = 16 , meter_number = 5123556, firmware_version = "10.3.22", switch_state = 1 },
            new Endpoint { serial_number = "2", ModelId = 17, meter_number = 5123556, firmware_version = "10.3.22", switch_state = 2 },
            new Endpoint { serial_number = "3", ModelId = 18 , meter_number = 5123556, firmware_version = "8.3.22", switch_state = 0 },
            new Endpoint { serial_number = "4", ModelId = 19 , meter_number = 5123556, firmware_version = "10.3.22", switch_state = 2 },
        };
        public void Insert(Endpoint enp)
        {
            try
            {
                endpoints.Add(enp);
                Console.WriteLine("New Endpoint added succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: \n" + ex.ToString());
            }
        }

        enum states
        {
            Disconnected = 0,
            Connected = 1,
            Armed = 2
        }

        public void Edit(string serial_number, int switch_state)
        {

            var sel_endpoint = endpoints.Where(e => e.serial_number == serial_number).FirstOrDefault();
            try
            {
                if (Enum.IsDefined(typeof(states), switch_state))
                    sel_endpoint.switch_state = switch_state;
                else
                {
                    Console.WriteLine("Invalid state! Enter a new one!");
                    string temp = Console.ReadLine();
                }

                Console.WriteLine("Switch state changed! \n Previous: " + switch_state + "\n Actual: " + sel_endpoint.switch_state);
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: \n" + ex.ToString());
            }

        }

        public void Delete(string serial_number)
        {
            var sel_endpoint = endpoints.Where(e => e.serial_number == ser).FirstOrDefault();
            endpoints.Remove(sel_endpoint);
            Console.WriteLine("Endpoint removed successfully.");
        }
        
        public void Find(string serial_number)
        {
            var endpointresult = endpoints.Where(s => string.Equals(s.serial_number, serial_number)).FirstOrDefault();
            Console.WriteLine("Endpoint Results: ");
            Console.WriteLine(endpointresult);
        }

        public void List()
        {
            Console.WriteLine("------------ Endpoints List ------------");
            foreach (Endpoint endpoint in endpoints.ToList())
            {
                Console.WriteLine(endpoint);
            }
        }
    }
}
