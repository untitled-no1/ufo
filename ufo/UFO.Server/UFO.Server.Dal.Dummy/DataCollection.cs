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
using Ploeh.AutoFixture;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Dummy
{
    sealed class DataCollection
    {
        public static readonly BlockingCollection<Artist> Artists = new BlockingCollection<Artist>();
        
        public static readonly BlockingCollection<User> Users = new BlockingCollection<User>();

        public static readonly BlockingCollection<Venue> Venues = new BlockingCollection<Venue>();
        
        public static readonly BlockingCollection<Performance> Performances = new BlockingCollection<Performance>();
        
        static DataCollection()
        {
            // User demo data
            // Password examples use MD5 hashing --> http://www.danstools.com/md5-hash-generator/
            var userList = new List<User>
            {
                new User
                {
                    EMail = "marius.dinu@mail.com",
                    FirstName = "Marius",
                    LastName = "Dinu",
                    Password = "cfefe3e7c1ce34edfd95f0386ab03724", // PW: theTools48297!
                    IsAdmin = true,
                    IsArtist = true
                },
                new User
                {
                    EMail = "chesterbenn@live.com",
                    FirstName = "Chester",
                    LastName = "Bennington",
                    Password = "098f6bcd4621d373cade4e832627b4f6", // PW: test
                    IsAdmin = false,
                    IsArtist = true
                },
                new User
                {
                    EMail = "shinoda@hotmail.com",
                    FirstName = "Mike",
                    LastName = "Shinoda",
                    Password = "a4f5dfd41d26f7fb0972ba8a77eead30", // PW: se8ndkKhHnd3821!D$
                    IsAdmin = false,
                    IsArtist = true
                },
                new User
                {
                    EMail = "hallo@mail.com",
                    FirstName = "Peter",
                    LastName = "Fox",
                    Password = "5f4dcc3b5aa765d61d8327deb882cf99", // PW: password
                    IsAdmin = false,
                    IsArtist = true
                }
            };
            for (var i = 0; i < 100; i++)
                userList.Add(DummyDataGenerator.GenerateUser());

            Users.AddRange(userList);
        }
    }

    public sealed class DummyDataGenerator
    {
        public static User GenerateUser()
        {
            var fixture = new Fixture();
            var user = fixture.Build<User>();

            fixture.Customize<User>(c => c
            .With(u => u.EMail, $"{fixture.Create<string>()}@{fixture.Create<string>()}.com")
            .With(u => u.FirstName, fixture.Create<string>())
            );

            return user.Create();
        }
    }
}
