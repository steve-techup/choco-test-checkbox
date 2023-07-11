using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Caretag_Class.Model;
using Moq;

namespace Tests.CheckboxStation
{
    public class BaseTest
    {
        protected readonly IFixture _fixture;

        public BaseTest()
        {
            _fixture = _fixture = new Fixture()
                .Customize(new AutoMoqCustomization());

            _fixture.Behaviors.Remove(_fixture.Behaviors.OfType<ThrowingRecursionBehavior>().First());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            
            var caretagModelMock = new Mock<CaretagModel>();
            
            _fixture.Register(() => caretagModelMock);
            _fixture.Register(() => caretagModelMock.Object);

        }

        protected List<string> GetTags(int count)
        {
            return Enumerable.Range(0, count).Select(i => _fixture.Create<int>().ToString()).ToList();
        }

    }
}
