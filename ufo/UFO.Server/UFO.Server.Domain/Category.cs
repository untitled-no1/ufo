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

namespace UFO.Server.Domain
{
    [Serializable]
    public class Category
    {
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"CategoryId: {CategoryId}, CategoryName: {Name}";
        }

        public override bool Equals(object obj)
        {
            var category = obj as Category;
            return category != null
                && CategoryId == category.CategoryId
                && Name == category.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = 33;
            hashCode += CategoryId?.GetHashCode() ?? 0;
            hashCode += Name?.GetHashCode() ?? 0;
            return hashCode;
        }
    }
}
