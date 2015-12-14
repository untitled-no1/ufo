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
using System.ComponentModel.DataAnnotations;

namespace UFO.Server.Domain
{
    [Serializable]
    public class User
    {
        public int UserId { get; set; } = Constants.InvalidIdValue;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [RegularExpression(Constants.EMailRegex)]
        public string EMail { get; set; }
        
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsArtist { get; set; }

        public Artist Artist { get; set; }

        public override string ToString()
        {
            return $"UserId: {UserId}, FirstName: {FirstName}, LastName: {LastName}, UserEMail: {EMail}, Artist: ({Artist})";
        }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            return user != null
                && Artist == user.Artist
                && FirstName == user.FirstName
                && LastName == user.LastName
                && EMail == user.EMail
                && Password == user.Password
                && IsAdmin == user.IsAdmin
                && IsArtist == user.IsArtist
                && Artist == user.Artist;
        }

        public override int GetHashCode()
        {
            var hashCode = 33;
            hashCode += FirstName?.GetHashCode() ?? 0;
            hashCode += LastName?.GetHashCode() ?? 0;
            hashCode += EMail?.GetHashCode() ?? 0;
            hashCode += Artist?.GetHashCode() ?? 0;
            return hashCode;
        }
        
    }
}
