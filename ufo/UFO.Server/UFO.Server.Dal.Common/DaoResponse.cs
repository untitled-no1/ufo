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
        Failed,
        Invalid,
        Unknown
    }

    /// <summary>
    /// DAO Interface response wrapper object holding status information, possible occurred 
    /// error messages and/or the resulting typed object.
    /// </summary>
    [Serializable]
    public class DaoResponse
    {
        public DaoStatus ResponseStatus { get; set; } = DaoStatus.Unknown;

        public Exception Exception { get; set; }

        public string ErrorMessage { get; set; }

        public object ResultObject { get; set; }

        public static DaoResponse<TResponse> QuerySuccessfull<TResponse>(TResponse responseObject)
        {
            return QueryResponse(responseObject, DaoStatus.Successful);
        }

        public static DaoResponse<TResponse> QueryFailed<TResponse>(TResponse responseObject, string errorMessage, Exception exception = null)
        {
            return QueryResponse(responseObject, DaoStatus.Failed, errorMessage, exception);
        }

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

        public DaoResponse<TDaoType> OnSuccess(Action<TDaoType> action)
        {
            if (ResponseStatus == DaoStatus.Successful)
                action(ResultObject);
            return this;
        }

        public DaoResponse<TDaoType> OnSuccess(Action<DaoResponse<TDaoType>> action)
        {
            if (ResponseStatus == DaoStatus.Successful)
                action(this);
            return this;
        }

        public DaoResponse<TDaoType> OnFailure(Action<DaoResponse<TDaoType>> action)
        {
            if (ResponseStatus != DaoStatus.Successful)
                action(this);
            return this;
        }
    }
}
