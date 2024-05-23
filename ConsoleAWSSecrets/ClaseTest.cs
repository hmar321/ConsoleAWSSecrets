using ConsoleAWSSecrets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAWSSecrets
{
    public class ClaseTest
    {
        private KeysModel keys;

        public ClaseTest(KeysModel keys)
        {
            this.keys = keys;
        }

        public string GetValue()
        {
            return this.keys.Api;
        }
    }
}
