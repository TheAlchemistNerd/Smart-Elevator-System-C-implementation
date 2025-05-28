using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Elevator_System
{
    public interface IRequestObserver
    {
        void OnNewRequest(FloorRequest request);
    }
}
