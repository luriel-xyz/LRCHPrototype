using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRCHPrototype
{
    internal class PhysicianPatientTagData
    {
        private int physicianNo;

        private int patientNo;

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

        public int PatientNo
        {
            get
            {
                return patientNo;
            }
            set
            {
                patientNo = value;
            }
        }

        /**
         * Parameterized constructor
         * 
         * <param name="physicianNo"></param>
         * <param name="patientNo"></param>
         */
        public PhysicianPatientTagData(int physicianNo, int patientNo)
        {
            PhysicianNo = physicianNo;
            PatientNo = patientNo;
        }
    }
}
