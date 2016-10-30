using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using OLXDataNinja.Models;

namespace OLXDataNinja
{
    class TrainingDataParser
    {
        public static TrainingDataModel Parse( string[] data )
        {
            var model = new TrainingDataModel
            {
                Id = int.Parse(data[0]),
                Title = data[1].Replace("\"", "").Replace("!", ""),
                UserActivityData = JsonConvert.DeserializeObject<Dictionary<int, int>>(data[2]),
                Photos = data[3].Replace("[", "").Replace("]", "").Replace("\"", "").Split(',').ToList(),
                L1Category = int.Parse(data[4])
            };

            if ( data.Length > 5 )
                model.L2Category = int.Parse(data[5]);
            if ( data.Length > 6 )
                model.L3Category = int.Parse(data[6]);
            return model;
        }
    }
}
