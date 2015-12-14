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
using System.Configuration;
using System.Reflection;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Extensibility;

namespace UFO.Server
{
    static class ProviderUtility
    {
        /// <summary>
        /// Load classes with reflection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyName">Name of the assebly to be loaded.</param>
        /// <param name="nameSpace">Namespace where the class is embedded.</param>
        /// <param name="className">Class name which will be instantiated.</param>
        /// <returns></returns>
        [LogException]
        public static T LoadClass<T>(string assemblyName, string nameSpace, string className)
        {
            try
            {
                var assembly = Assembly.Load(assemblyName);
                var type = assembly.GetType($"{nameSpace}.{className}");
                if (type != null)
                {
                    var obj = Activator.CreateInstance(type);
                    if (obj is T)
                        return (T)obj;
                }
            }
            catch
            {
                throw new SettingsPropertyNotFoundException($"Failed to load assembly or type: {assemblyName}");
            }
            throw new SettingsPropertyWrongTypeException($"Unsupported class load! Expected type: {typeof(T).Name}");
        }
    }
}
