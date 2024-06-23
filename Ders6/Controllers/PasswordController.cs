using Ders6.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Security.Cryptography;


namespace Ders6.Controllers
{
    public class PasswordController : Controller
    {
        private static readonly string FilePath = "password.txt";
        public IActionResult Index()
        {



            return View();
        }

        [HttpPost]
        public IActionResult Generate()
        {
            var passwordModel = new RandomPasswordGenerator
            {
                Password=GenerateRandomPassword(12),//rastgele şifre oluştur
                HashedPassword=HashPassword(GenerateRandomPassword(12)),
                GenerateDate=DateTime.Now
            };


            SavePassword(passwordModel);



            return View("Index",passwordModel);
        }

        //Random Password Oluştur
        private string GenerateRandomPassword(int length)
        {
            const string validchar = "ABCDEFERTYUIOPSDFGHJKLŞŞXCBNMÖMÖ123465789";
            StringBuilder res = new StringBuilder();

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(validchar[(int)(num % (uint)validchar.Length)]);
                }
            }
            return res.ToString();
        }

        private string HashPassword(string password)
        {

            using(SHA256 sha256Hash=SHA256.Create())
            {

                byte[]bytes=sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder=new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }

        }


        private void SavePassword(RandomPasswordGenerator passwordModel)
        {
            string data = $"{passwordModel.Password},{passwordModel.HashedPassword},{passwordModel.GenerateDate}\n";
            System.IO.File.AppendAllText(FilePath, data);
        }
    }
}
