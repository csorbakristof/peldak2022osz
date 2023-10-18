using System.Security.Cryptography;
using System.Text;

string code = "ABC124";
using(var sha = SHA1.Create())
{
    var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(code));
    var hashHex = Convert.ToHexString(hash);
    var hashBase64 = Convert.ToBase64String(hash);
    Console.WriteLine($"Hex: {hashHex}");
    Console.WriteLine($"Base64: {hashBase64}");

    var userID = hashBase64.Substring(0, 5).ToUpper();
    Console.WriteLine($"UserID: {userID}");

    const string salt = "X";

    var password = Convert.ToBase64String(
        sha.ComputeHash(Encoding.UTF8.GetBytes(userID + salt))).Substring(0,5).ToUpper();

    Console.WriteLine($"Password: {password}");
}


