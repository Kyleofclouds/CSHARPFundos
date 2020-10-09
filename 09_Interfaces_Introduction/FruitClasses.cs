using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _09_Interfaces_Introduction
{
    public class Banana : IFruit
    {
        public string Name { get { return "Banana"; } }
        public bool IsPeeled { get; private set; }
        public string Peel()
        {
            IsPeeled = true;
            return "You peel the banana";
        }
    }
    public class Orange : IFruit
    {
        public string Name { get { return "Orange"; } }
        public bool IsPeeled { get; private set; }
        public Orange() { }
        public Orange(bool isPeeled)
        {
            IsPeeled = isPeeled;
        }
        public string Peel()
        {
            IsPeeled = true;
            return "You peel the orange";
        }
        public string Squeeze()
        {
            return "You squeeze the orange and juice comes out.";
        }
    }
    public class Grape : IFruit
    {
        public string Name { get { return "Grape"; } }
        public bool IsPeeled { get; } = false;
        public string Peel()
        {
            return "Who peels grapes?";
        }

    }
    //10-15 minutes to create your own
    public class Apple : IFruit
    {
        public string Name { get { return "Apple"; }  }
        public bool IsPeeled { get; private set; } = false;
        public bool IsCored { get; private set; }

        public string AppleType = "Washington";
        public Apple() { }
        public Apple(string appleType)
        {
            AppleType = appleType;
        }
        public string Peel()
        {
            IsPeeled = false;
            return $"You peeled the {AppleType} apple";
        }
        public string Core()
        {
            IsCored = true;
            return $"The {AppleType} apple has been cored.";
        }
    }
}
