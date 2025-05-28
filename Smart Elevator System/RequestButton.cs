
namespace Smart_Elevator_System
{
    public class RequestButton
    {
        private readonly List<IRequestObserver> _observers = new();

        public void PressButton(int floor, Direction direction)
        {
            Console.WriteLine($"[Button] Floor {floor} - {direction} button pressed");
            NotifyObservers(new FloorRequest(floor, direction));
        }

        public void RegisterObserver(IRequestObserver observer)
        {
            _observers.Add(observer);
        }

        private void NotifyObservers(FloorRequest request)
        {
            foreach (var observer in _observers)
            {
                observer.OnNewRequest(request);
            }
        }
    }
}
