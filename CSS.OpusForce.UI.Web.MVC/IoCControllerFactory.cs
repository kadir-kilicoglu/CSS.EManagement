﻿using System;
using System.Web.Mvc;
using System.Web.Routing;

using StructureMap;

namespace CSS.OpusForce.UI.Web.MVC
{
    public class IoCControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }
}