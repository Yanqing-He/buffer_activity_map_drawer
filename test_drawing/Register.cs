using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_drawing
{
    class Register
    {
        //private ProcElem[] readElem;
        //private ProcElem[] writeElem;
        //private ProcElem readElem2;
        private int dataLeng;
        private double delay;

        //public Register(ProcElem[] read, ProcElem[] write)
        public Register()
        {
            delay = 2;
            dataLeng = 10;
        }

        public double Delay
        {
            get
            {
                return delay;
            }
            set
            {
                delay = value;
            }
        }

        public int DataLeng
        {
            get
            {
                return dataLeng;
            }
            set
            {
                dataLeng = value;
            }
        }
    }
}
