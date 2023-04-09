using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRCHPrototype
{
    internal class PhysicianTagData
    {
        private int physicianNo;

        private string physicianName;

        public int PhysicianNo
        {
            get
            {
                return physicianNo;
            }
            set
            {
                physicianNo = value;
            }
        }

        public string PhysicianName
        {
            get
            {
                return physicianName;
            }
            set
            {
                physicianName = value;
            }
        }

        public PhysicianTagData(int physicianNo, string physicianName)
        {
            PhysicianNo = physicianNo;
            PhysicianName = physicianName;
        }
    }
}
