#region copyright
// (C) Copyright 2015 Dinu Marius-Constantin (http://dinu.at) and others.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Contributors:
//     Dinu Marius-Constantin
//     Wurm Florian
#endregion
using System;
using System.Reflection;
using PostSharp.Aspects;
using PostSharp.Patterns.Diagnostics;

namespace UFO.Server.Dal.Common
{
    /// <summary>
    /// This class uses aspect oriented concepts to handle exceptions and 
    /// create a default return object for an generic and non-generic DaoResponse type.
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class DaoExceptionHandlerAttribute : OnExceptionAspect
    {
        private readonly Type _exceptionType;
        private readonly Type _returnType;

        /// <summary>
        /// The created exception handling aspect uses no specified exception and return type. 
        /// The resulting object will be of the non-generic implementation type.
        /// </summary>
        public DaoExceptionHandlerAttribute() : this(typeof(Exception))
        {
        }

        /// <summary>
        /// The created exception handling aspect uses a specified return type. 
        /// The resulting object type will be of the generic implementation type.
        /// </summary>
        /// <param name="returnType">Method resulting generic type.</param>
        public DaoExceptionHandlerAttribute(Type returnType) : this(typeof(Exception), returnType)
        {
        }

        /// <summary>
        /// The created exception handling aspect uses a specified exception and return type.
        /// Only exceptions of this type will be handled.
        /// The resulting object type will be of the generic implementation type.
        /// </summary>
        /// <param name="exceptionType">Exceptions which will be handled.</param>
        /// <param name="returnType">Method resulting generic type.</param>
        private DaoExceptionHandlerAttribute(Type exceptionType, Type returnType = null)
        {
            _exceptionType = exceptionType;
            _returnType = returnType;
        }

        /// <summary>
        /// Returns the exception type which has been caught.
        /// </summary>
        /// <param name="method"></param>
        /// <returns>Type of the occured exception</returns>
        public override Type GetExceptionType(MethodBase method)
        {
            return _exceptionType;
        }

        /// <summary>
        /// Exception handling logic. Implements the base behavior if an exception of type
        /// T occures. Returns a object of DaoResponse in generic or non-generic version
        /// depending on the specified type.
        /// </summary>
        /// <param name="args">Executing method.</param>
        [LogException]
        public override void OnException(MethodExecutionArgs args)
        {
            // set the method behavior after an exception occurred
            args.FlowBehavior = FlowBehavior.Return;

            // check if an return type is set
            if (_returnType == null)
            {
                // create non-generic response object
                var obj = Activator.CreateInstance<DaoResponse>();
                obj.ErrorMessage = args.Exception.Message;
                obj.ResponseStatus = DaoStatus.Failed;
                obj.Exception = args.Exception;

                // set return type value
                args.ReturnValue = obj;
            }
            else
            {
                // craete a generic typed response object
                var daoResponse = Type.GetType("UFO.Server.Dal.Common.DaoResponse`1");
                if (daoResponse != null)
                {
                    var property = daoResponse.GetProperty("ErrorMessage");
                    var objectCreator = daoResponse.MakeGenericType(_returnType);
                    var obj = Activator.CreateInstance(objectCreator);
                    property.SetValue(obj, args.Exception.Message);
                    property = daoResponse.GetProperty("ResponseStatus");
                    property.SetValue(obj, DaoStatus.Failed);
                    property = daoResponse.GetProperty("Exception");
                    property.SetValue(obj, args.Exception);

                    // set return type value
                    args.ReturnValue = obj;
                }
                else
                {
                    // throw exception for missing (unexcepted) type resource 
                    throw new InvalidOperationException("An unexpected reflection implementation expection occured!");
                }
            }
        }
    }
}
