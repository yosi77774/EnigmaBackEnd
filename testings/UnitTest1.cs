using EnigmaServer1.models;
using EnigmaServer1.Services;
using System;
using System.Text;
using Xunit;

namespace testings
{
    public class UnitTest1
    {

        EnigmaService _enigmaService = new EnigmaService();
        String result;
        String[] abc = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };


        [Fact]
        public async void Test1()
        {
            // Arrange
            var text = new StringBuilder();
            Random rnd = new Random();
            int[] numbers = new int[500];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(0, 25);
                text.Append(abc[numbers[i]]);
            }
            EncryptionRequest encryptionRequest = new EncryptionRequest();
            encryptionRequest.Text = text.ToString();
            encryptionRequest.keys = "DOG";

            //Act
            encryptionRequest.Text = await _enigmaService.Encryption(encryptionRequest);
            result = await _enigmaService.Encryption(encryptionRequest);
           


            //Assert
            Assert.Equal(text.ToString(), result);  

        }

        [Fact]
        public async void Test2()
        {
            // Arrange
            String CompText = "GSPHDX";
            EncryptionRequest encryptionRequest = new EncryptionRequest();
            encryptionRequest.Text = "ENIGMA";
            encryptionRequest.keys = "DOG";

            //Act
            result = await _enigmaService.Encryption(encryptionRequest);


            //Assert
            Assert.Equal(CompText, result);

        }

        [Fact]
        public async void Test3()
        {
            // Arrange
            String result;
            int count = 0;
            EncryptionRequest encryptionRequest = new EncryptionRequest();

            var text = new StringBuilder();
            Random rnd = new Random();
            int[] numbers = new int[1000];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(0, 25);
                text.Append(abc[numbers[i]]);
            }

            encryptionRequest.Text = text.ToString();
            encryptionRequest.keys = "DOG";

            //Act
            result = await _enigmaService.Encryption(encryptionRequest);

            //Assert
            foreach (var c in result)
            {
                    Assert.True(c != text[count++]);
            }

        }

    }
}
