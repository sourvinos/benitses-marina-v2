using System.Collections;
using System.Collections.Generic;

namespace Users {

    public class CreateInvalidUser : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return EmailAlreadyExists();
            yield return UsernameAlreadyExists();
        }

        private static object[] EmailAlreadyExists() {
            return [
                new TestNewUser {
                    StatusCode = 492,
                    Username = "newuser",
                    Displayname = "New User",
                    Email = "johnsourvinos@hotmail.com",
                    IsAdmin = false,
                    IsActive = true
                }
            ];
        }

        private static object[] UsernameAlreadyExists() {
            return [
                new TestNewUser {
                    StatusCode = 492,
                    Username = "john",
                    Displayname = "JOHN",
                    Email = "newemail@server.com",
                    IsAdmin = false,
                    IsActive = true
                }
            ];
        }

    }

}
