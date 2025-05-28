using Smart_Elevator_System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("\n=== Test 1: FloorRequest ===");
        var request = new FloorRequest(5, Direction.Up);
        Console.WriteLine(request);   // Expected: Request to floor 5 (Up)

        Console.WriteLine("\n=== Test 2: Elevator - Manual Movement ===");
        var elevator1 = new Elevator(1);
        elevator1.AddRequest(3);
        elevator1.Step();   // Move to floor 3

        elevator1.AddRequest(1);
        elevator1.Step();   // Move to floor 1

        Console.WriteLine("\n=== Test 3: Command Pattern ===");
        var elevator2 = new Elevator(2);
        var command = new MoveToFloorCommand(4);
        command.Execute(elevator2);    // Adds request
        elevator2.Step();    // Moves to floor 4

        Console.WriteLine("\n=== Test 4: Observer Pattern ===");
        var button1 = new RequestButton();
        var mockObserver = new MockRequestObserver();
        button1.RegisterObserver(mockObserver);
        button1.PressButton(6, Direction.Down);    // Observer receives request

        Console.WriteLine("\n=== Test 5: Integration Simulation ===");
        var system = new SimpleElevatorSystem();
        var button2 = new RequestButton();
        button2.RegisterObserver(system);

        button2.PressButton(2, Direction.Up);     // Elevator should move to 2
        button2.PressButton(5, Direction.Down);   // Elevator should move to 5

        Console.WriteLine("\n=== All Tests Complete ===");
    }
}