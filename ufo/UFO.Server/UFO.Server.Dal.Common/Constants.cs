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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace UFO.Server.Dal.Common
{
    /// <summary>
    /// Delegate to create filters for APIs, such as DAO.
    /// </summary>
    /// <typeparam name="TResult">Type of the resulting collection.</typeparam>
    /// <typeparam name="TCriteria">Type of the filter criteria.</typeparam>
    /// <param name="enumerable">Collection of elements.</param>
    /// <param name="criteria">The data component used to filter.</param>
    /// <returns>A collection of TResult values.</returns>
    public delegate IEnumerable<TResult> Filter<TResult, in TCriteria>(IEnumerable<TResult> enumerable, TCriteria criteria);

    public static class Extensions
    {
        /// <summary>
        /// Add multiple items from a collection to the concurrent collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">Concurrent collection for adding.</param>
        /// <param name="toAdd">Normal collection from where the elements will be add.</param>
        public static void AddRange<T>(this BlockingCollection<T> collection, IEnumerable<T> toAdd)
        {
            toAdd.AsParallel().ForAll(collection.Add);
        }
    }
}
