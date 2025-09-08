using System.Collections;
using System.Collections.Generic;

namespace Users {

    public class UpdateValidUserNotOwnRecord : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return AccountIsOwnedByAnotherUser();
        }

        private static object[] AccountIsOwnedByAnotherUser() {
            return [
                new TestUpdateUser {
                    StatusCode = 490,
                    Id = "e7e014fd-5608-4936-866e-ec11fc8c16da",
                    Username = "john",
                    Displayname = "John",
                    Email = "johnsourvinos@hotmail.com",
                    IsAdmin = true,
                    IsActive = true
                }
            ];
        }

    }

}
