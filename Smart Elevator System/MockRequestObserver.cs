using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Elevator_System
{
    public class MockRequestObserver : IRequestObserver
    {
        public void OnNewRequest(FloorRequest request)
        {
            Console.WriteLine($"[MockObserver] Received request: {request}");
        }
    }
}
