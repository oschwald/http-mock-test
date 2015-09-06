using HttpMock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        [Test]
        public void SUT_should_return_stubbed_response()
        {
            var stubHttp = HttpMockRepository.At("http://localhost:9191");

            const string expected = "<xml><>response>Hello World</response></xml>";
            stubHttp.Stub(x => x.Get("/endpoint"))
                    .Return(expected)
                    .OK();

            string result = new WebClient().DownloadString("http://localhost:9191/endpoint");

            Console.WriteLine("RESPONSE: {0}", result);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}