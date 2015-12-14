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
using System.ComponentModel.DataAnnotations;

namespace UFO.Server.Domain
{
    [Serializable]
    public class Artist
    {
        public int ArtistId { get; set; } = Constants.InvalidIdValue;

        public string Name { get; set; }

        [RegularExpression(Constants.EMailRegex)]
        public string EMail { get; set; }

        public Category Category { get; set; }

        public Country Country { get; set; }

        public BlobData Picture { get; set; }

        public string PromoVideo { get; set; }

        public override string ToString()
        {
            return $"ID: {ArtistId}, Name: {Name}, EMail: {EMail}";
        }
    }
}
