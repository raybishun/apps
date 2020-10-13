using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore31MSTestUnitTest.Models
{
    /* JSON Sample
     {
        "data": {
            "id": 2,
            "email": "janet.weaver@reqres.in",
            "first_name": "Janet",
            "last_name": "Weaver",
            "avatar": "https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg"
        },
        "ad": {
            "company": "StatusCode Weekly",
            "url": "http://statuscode.org/",
            "text": "A weekly newsletter focusing on software development, infrastructure, the server, performance, and the stack end of things."
        }
    }
     */

    public class TestDataRootObject
    {
        public TestUserData Data { get; set; }
        public TestAdData Ad { get; set; }
    }

    public class TestUserData
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
    }

    public class TestAdData
    {
        public string Company { get; set; }
        public string Url { get; set; }
        public string Text { get; set; }
    }
}
