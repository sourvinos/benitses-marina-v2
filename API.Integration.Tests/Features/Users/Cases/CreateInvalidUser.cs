using System.Collections;
using System.Collections.Generic;
using Infrastructure;

namespace Users {

    public class CreateInvalidUser : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return EmailAlreadyExists();
            yield return UsernameAlreadyExists();
        }

        private static object[] EmailAlreadyExists() {
            return new object[] {
                new TestNewUser {
                    StatusCode = 492,
                    Username = "newuser",
                    Displayname = "New User",
                    Email = "johnsourvinos@hotmail.com",
                    IsAdmin = false,
                    IsActive = true
                }
            };
        }

        private static object[] UsernameAlreadyExists() {
            return new object[] {
                new TestNewUser {
                    StatusCode = 492,
                    Username = "john",
                    Displayname = "JOHN",
                    Email = "newemail@server.com",
                    IsAdmin = false,
                    IsActive = true
                }
            };
        }

    }

}
