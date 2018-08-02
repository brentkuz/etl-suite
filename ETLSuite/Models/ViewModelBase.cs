using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ETLSuite.Models
{
    public abstract class ViewModelBase
    {
        public virtual string GetUrls()
        {
            return JsonConvert.SerializeObject(new UrlConstants());
        }
    }
}
