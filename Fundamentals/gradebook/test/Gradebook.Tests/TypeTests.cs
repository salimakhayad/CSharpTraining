using System;
using System.Globalization;
using System.Reflection;
using System.Reflection.Metadata;
using Xunit;

namespace GradeBook.Tests {

    public delegate string WriteLogDelegate (string logMessage);
     // u need to return a string and take a string to be compatible with this delegate

    public class TypeTests {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod () {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello");
            Assert.Equal (3, count);
        }
        string IncrementCount (string message) {
            count++;
            return message.ToLower ();
        }
        string ReturnMessage (string message) {
            count++;
            return message;
        }
       

        [Fact]
        public void Test1 () {
            var x = getInt ();
            setInt (ref x);

            Assert.Equal (42, x);
        }
        private void setInt (ref int x) {
            x = 42;
        }
        private int getInt () {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef () {
            var book1 = GetBook ("Book 1");
            GetBookSetName (ref book1, "New Name");

            Assert.Equal ("New Name", book1.Name);
        }
        private void GetBookSetName (ref InMemoryBook book, string name) {
            book = new InMemoryBook (name);
        }

        [Fact]
        public void CSharpIsPassByValue () {
            var book1 = GetBook ("Book 1");
            GetBookSetName (book1, "New Name");

            Assert.Equal ("Book 1", book1.Name);
        }
        private void GetBookSetName (InMemoryBook book, string name) {
            book = new InMemoryBook (name);
        }

        [Fact]
        public void CanSetNameFromReference () {
            var book1 = GetBook ("Book 1");
            setName (book1, "New Name");

            Assert.Equal ("New Name", book1.Name);
        }
        private void setName (InMemoryBook book, string name) {
            book.Name = name;
        }

        [Fact]
        public void StringBehaveLikeValueTypes () {
            string name = "Salim";
            var upper = MakeUpperCase (name);

            Assert.Equal ("Salim", name);
            Assert.Equal ("SALIM", upper);
        }
        public string MakeUpperCase (string parameter) {
            return parameter.ToUpper ();
        }

        [Fact] // attribute in xunit 
        public void GetBookReturnsDifferentObjects () {
            var book1 = GetBook ("Book 1");
            var book2 = GetBook ("Book 2");

            Assert.Equal ("Book 1", book1.Name);
            Assert.Equal ("Book 2", book2.Name);

            Assert.NotSame (book1, book2);

        }

        [Fact] // attribute in xunit 
        public void TwoVarsCanReferenceSameObjects () {
            var book1 = GetBook ("Book 1");
            var book2 = book1;

            Assert.Same (book1, book2); // cleaner
            // Assert.True(Object.ReferenceEquals(book1,book2)); 

        }

        private InMemoryBook GetBook (string name) {
            return new InMemoryBook (name);
        }

    }
}