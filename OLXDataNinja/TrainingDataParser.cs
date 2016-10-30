using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OLXDataNinja.Models;

namespace OLXDataNinja
{
    class TrainingDataParser
    {
        public static TrainingDataModel Parse(string[] data)
        {
            var model = new TrainingDataModel
            {
                Id = int.Parse(data[0]),
                Title = data[1].Replace("\"", ""),
                UserActivityData = JsonConvert.DeserializeObject<Dictionary<int, int>>(data[2]),
                Photos = data[3].Replace("[", "").Replace("]", "").Replace("\"", "").Split(',').ToList(),
                L1Category = int.Parse(data[4])
            };
            int number;
            if (data.Length < 6) return model;

            model.L2Category = int.Parse(data[5]);

            if (data.Length > 6 && int.TryParse(data[6], out number))
                model.L3Category = number;
            return model;
        }
    }
}
