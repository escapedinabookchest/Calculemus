using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculemus.Model;

namespace Calculemus.Controller
{
    public class CalculemusController
    {
        private CalculemusModel model;

        public CalculemusController()
        {
            model = new CalculemusModel(new Parser(), new Graph(new TopologicalSorting()));
            model.Parse(@"C:\Users\Hersenspinsel\Documents\GitHub\Calculemus\Calculemus\circuit.txt");
            model.Sort();
            model.Calculate();
        }
    }
}