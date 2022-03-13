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
        public List<Endpoint> endpoints = new List<Endpoint>
        {
            new Endpoint { serial_number = "1", MeterModel = new MeterModel(16), meter_number = 5123556, firmware_version = "10.3.22", switch_state = 1 },
            new Endpoint { serial_number = "2", MeterModel = new MeterModel(17), meter_number = 5123556, firmware_version = "10.3.22", switch_state = 2 },
            new Endpoint { serial_number = "3", MeterModel = new MeterModel(18), meter_number = 5123556, firmware_version = "8.3.22", switch_state = 0 },
            new Endpoint { serial_number = "4", MeterModel = new MeterModel(19), meter_number = 5123556, firmware_version = "10.3.22", switch_state = 2 },
        };
        public void Insert(Endpoint enp)
        {
            try
            {
                if (endpoints.Select(s => s.serial_number).Contains(enp.serial_number))
                {
                    Console.WriteLine("Endpoint already exists!");
                }
                else
                {
                    
                    endpoints.Add(enp);
                    Console.WriteLine("New Endpoint added succesfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: \n" + ex.ToString());
            }
        }

        public void Edit(string serial_number, int switch_state)
        {
            try
            {
                endpoints.FirstOrDefault(x => x.serial_number == serial_number).switch_state = switch_state;
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: \n" + ex.ToString());
            }

        }

        public void Delete(string serial_number)
        {
            var sel_endpoint = endpoints.Where(e => e.serial_number == serial_number).FirstOrDefault();
            endpoints.Remove(sel_endpoint);
            Console.WriteLine("Endpoint removed successfully.");
        }

        public void Find(string serial_number)
        {
            var endpointresult = endpoints.Where(s => s.serial_number == serial_number).FirstOrDefault();
            Console.WriteLine("Endpoint Results: ");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("\t Serial number: " + endpointresult.serial_number);
            Console.WriteLine("\t model id: " + endpointresult.MeterModel.ModelId);
            Console.WriteLine("\t model: " + endpointresult.MeterModel.ModelName);
            Console.WriteLine("\t meter number: " + endpointresult.meter_number);
            Console.WriteLine("\t firmware ver:" + endpointresult.firmware_version);
            Console.WriteLine("\t switch state: " + endpointresult.switch_state);
            Console.WriteLine("-----------------------------------------");
        }

        public void List()
        {
            Console.WriteLine("------------ Endpoints List ------------");

            foreach (Endpoint endpoint in endpoints.ToList())
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("\t Serial number: " + endpoint.serial_number);
                Console.WriteLine("\t model id: " + endpoint.MeterModel.ModelId);
                Console.WriteLine("\t model: " + endpoint.MeterModel.ModelName);
                Console.WriteLine("\t meter number: " + endpoint.meter_number);
                Console.WriteLine("\t firmware ver:" + endpoint.firmware_version);
                Console.WriteLine("\t switch state: " + endpoint.switch_state);
                Console.WriteLine("-----------------------------------------");
            }
        }

        public bool ValidateExistantSerial(string serial)
        {
            return endpoints.Select(s => s.serial_number).Contains(serial);
        }
    }
}
