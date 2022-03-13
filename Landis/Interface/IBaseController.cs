using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landis.Interface
{
    public interface IBaseController
    {

        void Insert(Endpoint enp);
        void Edit(string serial_number, int switch_state);
        void Delete(string serial_number);
        void List();
        void Find(string serial_number);
        bool ValidateExistantSerial(string serial);
    }
}
