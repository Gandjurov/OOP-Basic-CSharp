using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital
{
    public class Room
    {
        private List<string> patients;

        public Room()
        {
            this.Patients = new List<string>();
        }

        public List<string> Patients
        {
            get { return patients; }
            set { patients = value; }
        }

    }
}
