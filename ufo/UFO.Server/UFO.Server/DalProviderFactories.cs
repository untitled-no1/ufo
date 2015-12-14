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

using NLog;
using PostSharp.Patterns.Diagnostics;
using UFO.Server.Dal.Common;
using UFO.Server.Properties;
using LogLevel = NLog.LogLevel;
using PostSharp.Extensibility;

namespace UFO.Server
{
    public static class DalProviderFactories
    {
        /// <summary>
        /// Creates a DAO factory at runtime, which provides methods for DAO creation.
        /// This is used to create loose coupling between assemblies using technology proprietary implementations
        /// and the business logic libraries.
        /// </summary>
        /// <param name="assemblyName">Name of the assebly to be loaded.</param>
        /// <param name="nameSpace">Namespace where the class is embedded.</param>
        /// <param name="providerName">Class name provider which will be instantiated.</param>
        /// <returns>DAO provider factory.</returns>
        public static IDaoProviderFactory GetDaoFactory(string assemblyName = null, string nameSpace = null, string providerName = null)
        {
            return ProviderUtility.LoadClass<IDaoProviderFactory>(
                assemblyName ?? Settings.Default.DaoProviderAssemblyName,
                nameSpace ?? Settings.Default.DaoProviderNameSpace,
                providerName ?? Settings.Default.DaoProviderClassName);
        }
    }
}
