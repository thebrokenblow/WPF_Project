using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project
{
    public class ModelData
    {
        public Guid id { get; set; }
        public string Value { get; set; }
        public ModelData()
        {
            id = Guid.NewGuid();
        }
    }
}
