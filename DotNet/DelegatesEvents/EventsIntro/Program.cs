using System;

namespace EventsIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            MyEasyEvent myEasyEvent = new MyEasyEvent();

            //Attach Event Handler
            myEasyEvent.EasyEventRaised += HandleEasyEvent;

            //Raise Event
            myEasyEvent.RaiseMyEasyEvent(2, 4);
            Console.ReadLine();
        }

        //Event Handler
        public static void HandleEasyEvent(int a, int b)
        {
            Console.WriteLine("Sum : {0}",a+b);
        }
    }

    //Delegate for my Event
    public delegate void RaiseEasyEvent(int a, int b);

    //Event Class
    public class MyEasyEvent
    {
        //Event declaration
        public event RaiseEasyEvent EasyEventRaised;

        //Raise Event
        public void RaiseMyEasyEvent(int a, int b)
        {
            EasyEventRaised.Invoke(a, b);
        }
    }
}
