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
using System.Collections.Generic;
using System.Diagnostics;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Common
{
    public enum DaoStatus
    {
        Successful,
        EmptyResult,
        Failed
    }

    /// <summary>
    /// DAO Interface response wrapper object holding status information, possible occurred 
    /// error messages and/or the resulting typed object.
    /// </summary>
    [Serializable]
    public class DaoResponse
    {
        public DaoStatus ResponseStatus { get; set; }

        public Exception Exception { get; set; }

        public string ErrorMessage { get; set; }

        public object ResultObject { get; set; }

        /// <summary>
        /// Create a DaoResponse object with a DaoStatus member set to Successful.
        /// </summary>
        /// <typeparam name="TResponse">Response type.</typeparam>
        /// <param name="responseObject">Response object of type TResponse.</param>
        /// <returns>DaoResponse with successful flag.</returns>
        public static DaoResponse<TResponse> QuerySuccessful<TResponse>(TResponse responseObject)
        {
            return QueryResponse(responseObject, DaoStatus.Successful);
        }

        /// <summary>
        /// Create a DaoResponse object with a DaoStatus member set to EmptyResult.
        /// </summary>
        /// <returns>DaoResponse with successful flag, but no real result object. Result value is set to default.</returns>
        public static DaoResponse<TResponse> QueryEmptyResult<TResponse>()
        {
            return QueryResponse(default(TResponse), DaoStatus.EmptyResult);
        }

        /// <summary>
        /// Create a DaoResponse object with a DaoStatus member set to Failed.
        /// </summary>
        /// <typeparam name="TResponse">Response type.</typeparam>
        /// <param name="responseObject">Response object of type TResponse.</param>
        /// <param name="errorMessage">Reason why the DaoResponse failed.</param>
        /// <param name="exception">Exception that might have occured, which lead to failed response.</param>
        /// <returns></returns>
        public static DaoResponse<TResponse> QueryFailed<TResponse>(TResponse responseObject, string errorMessage, Exception exception = null)
        {
            return QueryResponse(responseObject, DaoStatus.Failed, errorMessage, exception);
        }

        /// <summary>
        /// Create a DaoResponse object with a DaoStatus and in case of a failure with the meta-information why the
        /// request failed.
        /// </summary>
        /// <typeparam name="TResponse">Response type.</typeparam>
        /// <param name="status">Response object status flag.</param>
        /// <param name="responseObject">Response object of type TResponse.</param>
        /// <param name="errorMessage">Reason why the DaoResponse failed.</param>
        /// <param name="exception">Exception that might have occured, which lead to failed response.</param>
        /// <returns></returns>
        public static DaoResponse<TResponse> QueryResponse<TResponse>(TResponse responseObject, DaoStatus status, string errorMessage = "", Exception exception = null)
        {
            var daoResponse = new DaoResponse<TResponse>
            {
                ErrorMessage = errorMessage,
                ResponseStatus = status,
                ResultObject = responseObject,
                Exception = exception
            };
            return daoResponse;
        }
    }

    /// <summary>
    /// Typed DAO Interface response wrapper object.
    /// </summary>
    /// <typeparam name="TDaoType"></typeparam>
    [Serializable]
    public class DaoResponse<TDaoType> : DaoResponse
    {
        public new TDaoType ResultObject { get; set; }
        
        /// <summary>
        /// Delegates and executes an Action with parameter of type TDaoType, 
        /// if a successful response has occurred.
        /// </summary>
        /// <param name="action">Action to be executed on successful response.</param>
        /// <returns>Returns itself for a fluent interface concept.</returns>
        public DaoResponse<TDaoType> OnSuccess(Action<TDaoType> action)
        {
            if (ResponseStatus == DaoStatus.Successful)
                action(ResultObject);
            return this;
        }

        /// <summary>
        /// Delegates and executes an Action with parameter of type DaoResponse and inner type TDaoType, 
        /// if a successful response has occurred.
        /// </summary>
        /// <param name="action">Action to be executed on successful response.</param>
        /// <returns>Returns itself for a fluent interface concept.</returns>
        public DaoResponse<TDaoType> OnSuccess(Action<DaoResponse<TDaoType>> action)
        {
            if (ResponseStatus == DaoStatus.Successful)
                action(this);
            return this;
        }

        /// <summary>
        /// Delegates and executes an Action without parameters, 
        /// if a successful response has occurred.
        /// </summary>
        /// <param name="action">Action to be executed on successful response.</param>
        /// <returns>Returns itself for a fluent interface concept.</returns>
        public DaoResponse<TDaoType> OnSuccess(Action action)
        {
            if (ResponseStatus == DaoStatus.Successful)
                action();
            return this;
        }

        /// <summary>
        /// Delegates and executes an Action without parameters, 
        /// if a successful but empty result response has occurred.
        /// This means the ResultObject of the ResponseStatus is null.
        /// </summary>
        /// <param name="action">Action to be executed on successful but empty response.</param>
        /// <returns>Returns itself for a fluent interface concept.</returns>
        public DaoResponse<TDaoType> OnEmptyResult(Action action)
        {
            if (ResponseStatus == DaoStatus.EmptyResult)
                action();
            return this;
        }

        /// <summary>
        /// Delegates and executes an Action with parameter of type DaoResponse and inner type TDaoType, 
        /// if a failed response has occurred. This concept works only if the interface methods use
        /// the DaoExceptionHandlerAttribute to catch and wrap exceptions within a DaoResponse.
        /// </summary>
        /// <param name="action">Action to be executed on failed response.</param>
        /// <returns>Returns itself for a fluent interface concept.</returns>
        public DaoResponse<TDaoType> OnFailure(Action<DaoResponse<TDaoType>> action)
        {
            if (ResponseStatus == DaoStatus.Failed)
                action(this);
            return this;
        }
    }
}
