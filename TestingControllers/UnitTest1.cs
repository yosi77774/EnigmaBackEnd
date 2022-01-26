
using demo1.Services;
using System;
using System.Text;
using Xunit;

namespace TestingControllers
{
    public class UnitTest1
    {

        public EnigmaService _enigmaService;

        public UnitTest1(EnigmaService enigmaService)
        {
            _enigmaService = enigmaService;
        }
        [Fact]
        public async void Test1()
        {
            String EncryptionText = "ENIGMA";
            String Keys = "DOG";
            StringBuilder result;
            result= await _enigmaService.Encryption(Keys, EncryptionText);
            // Arrange


            //Act

            //Assert
        }
    }
}
