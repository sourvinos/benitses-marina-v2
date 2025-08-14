using System.Collections;
using System.Collections.Generic;

namespace Users {

    public class UpdateInvalidUser : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            // yield return UsernameAlreadyExists();
            yield return EmailAlreadyExists();
        }

        private static object[] UsernameAlreadyExists() {
            return new object[] {
                new TestUpdateUser {
                    StatusCode = 492,
                    Id = "eae03de1-6742-4015-9d52-102dba5d7365",
                    Username = "john",
                    Displayname = "JOHN",
                    Email = "gatopoulidis@gmail.com",
                    IsAdmin = false,
                    IsActive = true
                }
            };
        }

        private static object[] EmailAlreadyExists() {
            return new object[] {
                new TestUpdateUser {
                    StatusCode = 492,
                    Id = "e7e014fd-5608-4936-866e-ec11fc8c16da",
                    Username = "wow",
                    Displayname = "Wow",
                    Email = "email@server.com",
                    IsAdmin = false,
                    IsActive = true
                }
            };
        }

    }

}
