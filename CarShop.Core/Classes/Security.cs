using System.Security.Cryptography;
using System.Text;

namespace CarShop.Core.Classes;

public class Security
{
    public async Task<string> HashPassword(string password)
    {
        MD5 md5 = MD5.Create();
        byte[] mainBytes = ASCIIEncoding.Default.GetBytes(password);
        byte[] hashBytes = md5.ComputeHash(mainBytes);

        return await Task.FromResult(BitConverter.ToString(hashBytes));
    }
}
