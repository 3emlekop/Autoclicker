using System;
using System.Threading;

class Program
{
    private static bool continueSimulating = true;

    static void Main()
    {
        Thread simulationThread = new Thread(SimulateKeyPress);
        simulationThread.Start();

        Console.WriteLine("Press F1 to stop the simulation.");
        while (true)
        {
            if (Console.KeyAvailable == false)
            {
                break;
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.F1)
            {
                continueSimulating = false;
                break;
            }
        }
        simulationThread.Join();
    }

    static void SimulateKeyPress()
    {
        while (continueSimulating)
        {
            InputManager.LeftMouseButtonClick();
            Thread.Sleep(100);
        }
    }
}
