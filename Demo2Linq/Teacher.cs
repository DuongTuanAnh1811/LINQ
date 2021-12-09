using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo2linq
{
    class Teacher : Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Income { get; set; }
        public string Address { get; set; }
        public double Taxcoe { get; set; }
        TaxCoe tax = new TaxCoe();
        public double TaxCoe()
        {
            return Income * tax.GetTaxCoe(this) / 100;
        }
    }

}
