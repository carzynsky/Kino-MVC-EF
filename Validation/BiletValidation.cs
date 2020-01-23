using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinoDotNetCore.Validation
{
    public class BiletValidation
    {
        private List<string> list = new List<string>()
        {
            "zapłacony",
            "zaplacony",
            "wykorzystany",
            "niewykorzystany"
        };


        public BiletValidation()
        {

        }

        public bool IsValid(string stanBiletu)
        {
            string tmp = stanBiletu.ToLower();
            foreach(var x in list)
            {
                if (tmp == x)
                    return true;
            }
            return false;
        }
}
}
