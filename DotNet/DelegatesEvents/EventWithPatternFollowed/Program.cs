using System;

namespace EventWithPatternFollowed
{
    class Program
    {
        static void Main(string[] args)
        {
            MyEasyEvent myEasyEvent = new MyEasyEvent();

            //Attach Event Handler
            myEasyEvent.EasyEventRaised += HandleEasyEvent;
            myEasyEvent.RaiseMyEasyEvent(2, 4);
            Console.ReadLine();
        }

        //Handle Event
        public static void HandleEasyEvent(object sender, EasyEventArgs args)
        {
            Console.WriteLine("Sum : {0}", args.leftValue + args.rightValue);
        }
    }

    //Delegate for event
    public delegate void RaiseEasyEvent(int a, int b);

    //Event Class
    public class MyEasyEvent
    {
        //Create Event
        public event EventHandler<EasyEventArgs> EasyEventRaised;

        //Raise Event
        public void RaiseMyEasyEvent(int a, int b)
        {
            EasyEventArgs args = new EasyEventArgs() { leftValue = a, rightValue = b};
            string sender = "EasyEvent";
            EasyEventRaised.Invoke(sender,args);
        }
    }

    //Event Arguement Class
    public class EasyEventArgs : EventArgs
    {
        public int leftValue;
        public int rightValue;
    }
}
