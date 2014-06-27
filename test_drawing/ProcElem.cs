using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_drawing
{
    class ProcElem
    {
        public ProcElem()
        {
            freq = 1;
            latency = 5;
            hopPoint = 1.5;
        }
        private double freq;
        private int latency;
        private double hopPoint;

        public double Freq
        {
            get
            {
                return freq;
            }
            set
            {
                freq = value;
            }
        }

        public int Latency
        {
            get
            {
                return latency;
            }
            set
            {
                latency = value;
            }
        }

        public double HopPoint
        {
            get
            {
                return hopPoint;
            }
            set
            {
                hopPoint = value;
            }
        }
    }
}
