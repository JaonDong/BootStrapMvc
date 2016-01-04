﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using IocClass;

namespace BeginZore.IocMvc
{
    public class MyDefaultControllerFactory: DefaultControllerFactory
    {
        /// <summary>
        /// Reference to DI kernel.
        /// </summary>
        private readonly IIocResolver _iocManager;

        /// <summary>
        /// Creates a new instance of WindsorControllerFactory.
        /// </summary>
        /// <param name="iocManager">Reference to DI kernel</param>
        public MyDefaultControllerFactory(IIocResolver iocManager)
        {
            _iocManager = iocManager;
        }

        /// <summary>
        /// Called by MVC system and releases/disposes given controller instance.
        /// </summary>
        /// <param name="controller">Controller instance</param>
        public override void ReleaseController(IController controller)
        {
            _iocManager.Release(controller);
        }

        /// <summary>
        /// Called by MVC system and creates controller instance for given controller type.
        /// </summary>
        /// <param name="requestContext">Request context</param>
        /// <param name="controllerType">Controller type</param>
        /// <returns></returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }

            return (IController)_iocManager.Resolve(controllerType);
        }
    }
}