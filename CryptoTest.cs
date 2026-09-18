using System.Security.Cryptography;
using System.Text;

namespace Test
{
    public static class CryptoTest
    {
        #region Crypto
        // 1. 配置固定的 AES 密钥 (HEX格式)
        private static readonly byte[] AesKey = HexStringToBytes("8740e7e954662987965830b1c981b9dd9a09d3ce97dd50909b8f122391b9ff71");

        // 1. 配置固定的 AES 密钥 (Base64格式)
        //private static readonly byte[] AesKey = Convert.FromBase64String("h0Dn6VRmKYeWWDCxyYG53ZoJ086X3VCQm48SI5G5/3E=");

        /// <summary>
        /// 按照 HKM 系统规则加密明文密码
        /// </summary>
        /// <param name="plainTextPassword">明文密码</param>
        /// <returns>Base64(IV + 密文)</returns>
        public static string EncryptPassword(string plainTextPassword)
        {
            // 第一步：对明文密码进行 SHA-256 哈希，并转为小写 HEX 字符串
            string sha256Hex = ComputeSha256Hex(plainTextPassword);

            Console.WriteLine("sha256Hex:"+sha256Hex);



            // 第二步：每次加密随机生成 16字节 (128 bits) 的 IV
            byte[] iv = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(iv);
            }

            //测试IV
            iv = HexStringToBytes("a1953df68b9611bbffd033fee59cb47c");

            // 第三步：使用 AES-CFB (8位反馈) 加密 SHA-256 的 HEX 字符串
            byte[] encryptedBytes;
            byte[] plainBytes = Encoding.UTF8.GetBytes(sha256Hex);

            using (var aes = Aes.Create())
            {
                // 注意：KeySize/BlockSize 必须在 Key/IV 之前设置，
                // 否则会清除已设置的 Key/IV（之后会随机生成，导致结果错误）
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Key = AesKey;
                aes.IV = iv;
                aes.Mode = CipherMode.CFB;
                aes.Padding = PaddingMode.None;      // 必须为 None
                aes.FeedbackSize = 8;                // 关键：反馈位数为 8 bits
                                                       // 【关键修改】：文档虽然写着 8 bits，但实际期望结果是 128 bits (CFB-128)
                                                       // C# 默认就是 128，这里显式写出来以防万一

                using (var encryptor = aes.CreateEncryptor())
                {
                    // 直接对字节数组进行转换，这是最精确的方式
                    encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                }
            }

            string hex = BitConverter.ToString(encryptedBytes).Replace("-", "").ToLower();

            Console.WriteLine("encryptedHEX:"+ hex);

            Console.WriteLine("encryptedBase64:" + Convert.ToBase64String(encryptedBytes));

            // 第四步：将 IV 和 密文拼接，并进行 Base64 编码
            byte[] ivAndCipher = new byte[iv.Length + encryptedBytes.Length];
            Buffer.BlockCopy(iv, 0, ivAndCipher, 0, iv.Length);
            Buffer.BlockCopy(encryptedBytes, 0, ivAndCipher, iv.Length, encryptedBytes.Length);

            string ivAndCipherhex = BitConverter.ToString(ivAndCipher).Replace("-", "").ToLower();

            Console.WriteLine("iv+encrypted:" + ivAndCipherhex);

            return Convert.ToBase64String(ivAndCipher);
        }


        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="key">传入参数</param>
        /// <returns></returns>
        public static string GetMD5(string key)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
                var strResult = BitConverter.ToString(result);
                string result3 = strResult.Replace("-", "");
                return result3;
            }
        }


        /// <summary>
        /// 计算 SHA-256 并返回小写 HEX 字符串
        /// </summary>
        private static string ComputeSha256Hex(string input)
        {
            // 确保去除可能存在的首尾不可见空格
            input = input.Trim();

            // 使用原生的 SHA256 算法计算字节
            byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));

            // 转换为小写 HEX
            var sb = new StringBuilder(hashBytes.Length * 2);
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将 HEX 字符串转换为字节数组
        /// </summary>
        private static byte[] HexStringToBytes(string hex)
        {
            if (hex.Length % 2 != 0)
                throw new ArgumentException("HEX string length must be even.");

            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
        #endregion
    }
}
