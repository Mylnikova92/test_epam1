using System;
using System.Collections.Generic;
using System.Text;


namespace Nunit_test.businesobject
{
    class Product
    {
        public Product(string fullname)
        {
            
            Fullname = fullname;
        }

       

        public string Fullname { get; set; }

    }
}
