using System;
using System.Collections.Generic;

namespace Observer_Pattern_Getter_Setter_Example_1
{
    interface IStateObserver//OOP abstraction
    {
        void Notify();
    }
    abstract class BaseObservable//OOP abstraction
    {
        protected abstract void NotifyAllObservers();
    }
    class Observer1 : IStateObserver
    {
        public void Notify()
        {
            Console.WriteLine("Observer1");
        }
    }
    class Observer2 : IStateObserver
    {
        public void Notify()
        {
            Console.WriteLine("Observer2");
        }
    }
    class Observer3 : IStateObserver
    {
        public void Notify()
        {
            Console.WriteLine("Observer3");
        }
    }
    class Person : BaseObservable//inheritance Is-a
    {
        private List<IStateObserver> _Observables;//one-to-many dependency OOP.Has-a
        private String _name;
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                this.NotifyAllObservers();
            }
        }
        public Person()
        {
            _Observables = new List<IStateObserver>();
            _Observables.Add(new Observer1());
            _Observables.Add(new Observer2());
            _Observables.Add(new Observer3());
        }
        protected override void NotifyAllObservers()
        {
            _Observables.ForEach(x => x.Notify());
        }
        public override string ToString()
        {
            return Name;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Name = "Can Koç";
            Console.WriteLine(p);
        }
    }
}
