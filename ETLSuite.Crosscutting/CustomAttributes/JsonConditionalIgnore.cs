using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ETLSuite.Crosscutting.CustomAttributes
{
    public class JsonConditionalIgnore : Attribute
    {
        protected Type type;

        public JsonConditionalIgnore(Type type)
        {
            this.type = type;
        }

        public Type Type
        {
            get { return type; }
            set { type = value; }
        }

        public override bool Match(object obj)
        {
            return base.Match(obj);
        }
    }

}
