using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ETLSuite.Crosscutting.CustomAttributes;
using Newtonsoft.Json;


namespace ETLSuite.Models
{
    public class ViewModelBase
    {       
        public virtual string GetClientConfig()
        {
            var dict = new Dictionary<string, string>();
            var props = this.GetType().GetProperties();
            foreach (PropertyInfo p in props)
            {
                if (Attribute.IsDefined(p, typeof(ClientConfigurationAttribute)))
                    dict.Add(p.Name, p.GetValue(this)?.ToString());
            }

            return JsonConvert.SerializeObject(dict);
        }
        public virtual string GetUrls()
        {
            return JsonConvert.SerializeObject(new UrlConstants());
        }
    }
}
