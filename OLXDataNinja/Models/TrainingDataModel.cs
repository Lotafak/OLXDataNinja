﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLXDataNinja.Models
{
    class TrainingDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Dictionary<int, int> UserActivityData { get; set; }
        public List<string> Photos { get; set; }
        public int L1Category { get; set; }
        public int L2Category { get; set; }
        public int L3Category { get; set; }
    }
}
