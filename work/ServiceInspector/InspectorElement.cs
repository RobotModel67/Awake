using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ServiceModel.Configuration;

namespace Finandina.TPaga.WCFServices.ServiceInspector
{
    public class InspectorElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(InspectorBehavior); }
        }
        protected override object CreateBehavior()
        {
            return new InspectorBehavior();
        }
    }
}