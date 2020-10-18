using System;
using System.Numerics;
using System.Collections.Generic;
using System.Security.Cryptography;
using static Code.Encryption.CaesarCipher;

namespace Code.Encryption
{
    public class RSA
    {
        private readonly static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        public static List<BigInteger> RSAKeyGen()
        {
            //Basic implementation of RSA key generator. Uses helper functions to generate realistically large primes
            var keys = new List<BigInteger>();
            var firstPrime = OptimusPrime();
            var secondPrime = OptimusPrime();
            BigInteger n = BigInteger.Multiply(firstPrime, secondPrime);
            BigInteger v = BigInteger.Multiply(firstPrime-1, secondPrime-1);
            var littleK = SmallK(v);
            var d = CalcD(v, littleK);
            //Inefficient code use but it's only four elements
            keys.Add(littleK);
            keys.Add(n);
            keys.Add(d);
            keys.Add(n);
            return keys;
        }
        public static BigInteger OptimusPrime()
        {
            //64 byte array for 512 bit integer
            //Changed to 8 bytes for now due to debugging constraints
            byte[] randomOdd = new byte[8];
            var prime = false;
            //Fills array with cryptographically secure values
            rngCsp.GetBytes(randomOdd);
            var generatedNumber = new BigInteger(randomOdd);
            generatedNumber = BigInteger.Abs(generatedNumber); //In case it's negative which is what I think is happening somehow - but it doesn't make sense as a byte type is an unsigned integer so it has to be positive :(
            //If it's even it just adds one to it to make it odd
            if (generatedNumber % 2 == 0) generatedNumber += 1;
            //Calls helper function to check if generated random numbers are prime, if not it increments 2 to it and tries again. Very similar to OpenSSL algorithm [source, stackexchange]
            while (prime == false){
                if (MillerRabin(generatedNumber)) return generatedNumber;
                else generatedNumber += 2;
            }  
            //Should never return 0, function is completely wrong if it does.
            return 0;
        }
        public static bool IsPrime(BigInteger input)
        {
            BigInteger root = (BigInteger)Math.Pow(Math.E, BigInteger.Log(input) / 2);
            //This standard "naive" division method seems to be much too slow, takes way too long - so when we actually did find a prime number it wouldn't hang it's just trying to find if it's prime. Hmph.
            /*
            for (var i = 3; i <= root; i +=2){   
                Console.WriteLine(i); //Iterates through odd numbers as even ones are divisible by 2 which is a waste of computations
                if (input % i == 0){
                    return false;
                }
            }
            return true;
            */
            // Instead I am going to use a composite/probability check if the number is prime or not otherwise it will take FOREVER.
            return false;

        }
        //The next three functions make up an implementation of the Miller Rabin primality test. This is not my work, and I barely understand how it works.
        //As far as I understand it uses Fermat's prime theorem and attempts to find a contradiction to this - and if it cannot then the chances are fairly good it's prime. 
        public static bool MillerRabin(BigInteger n)
        {
            BigInteger[] ar;
            if (n < 4759123141) ar = new BigInteger[] { 2, 7, 61 };
            else if (n < 341550071728321) ar = new BigInteger[] { 2, 3, 5, 7, 11, 13, 17 };
            else ar = new BigInteger[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };
            BigInteger d = n - 1;
            int s = 0;
            //VariableNames.dll has crashed
            while ((d & 1) == 0) { d >>= 1; s++; }
            int i, j;
            for (i = 0; i < ar.Length; i++)
            {
                BigInteger a = BigInteger.Min(n-2, ar[i]);
                BigInteger now = pow(a, d, n);
                //More one liner goodness
                if (now == 1) continue;
                if (now == n - 1) continue;
                for (j = 1; j < s; j++)
                {
                    now = mul(now, now, n);
                    if (now == n - 1) break;
                }
                if (j == s) return false;
            }
            return true;
        }
        //This is a helper for the Miller Rabbin function, also do not understand what this does but it works ¯\_(ツ)_/¯
        public static BigInteger mul(BigInteger a, BigInteger b, BigInteger mod)
        {
            int i;
            BigInteger now = 0;
            for (i = 63; i >= 0; i--) if (((a >> i) & 1) == 1) break;
            for (; i >= 0; i--)
            {
                now <<= 1;
                while (now > mod) now -= mod;
                if (((a >> i) & 1) == 1) now += b;
                while (now > mod) now -= mod;
            }
            return now;
        }
        //Same case as above, with some bonus recursion going on. 
        public static BigInteger pow(BigInteger a, BigInteger p, BigInteger mod)
        {
            if (p == 0) return 1;
            if (p % 2 == 0) return pow(mul(a, a, mod), p / 2, mod);
            return mul(pow(a, p - 1, mod), a, mod);
        }
        public static int SmallK(BigInteger v)
        {
            //Calculates value of k by incrementing by 2 whenever the GCD is not 1 - i.e. they are not coprimes. 
            var k = 3;
            while (BigInteger.GreatestCommonDivisor((BigInteger) k, v) != 1) k += 2;
            return k;
        }
        public static BigInteger CalcD(BigInteger v, int k)
        {
            var done = false;
            while (done == false){
                var d = (v+1)/k;
                //I know that v+1 mod v will return 1, so I'm essentially trying to find a whole number which will multiply by k and mod by v to get 1. 
                if (d%1 == 0) return d;
                //Multiplies by 2 if it's not a whole number and tries again. 
                else v *= 2;
            }
            //Should never return this or something is very wrong.
            return 1;
        }
        public static BigInteger RSAEncode(string userInput)
        {
            var asciiRep = new List<int>();
            foreach (var i in userInput) asciiRep.Add(Convert.ToInt32(i));
            //String manipulation - I'm basically converting each letter to it's ascii value which will always be 2 digits if the letters are all uppercase. This will make it infinitely easier to decode later on. 
            var workString = String.Join("", asciiRep);
            var encodedMessage = BigInteger.Parse(workString);
            //Generating keys to encrypt 
            var secureKeys = RSAKeyGen();
            Console.WriteLine("Keys - k, n, d, n in that order. Keep these safe!");
            foreach (var i in secureKeys) Console.WriteLine(i);
            //This is the encryption stage - the ascii number converted message is then raised to the power of k, and then the modulus of n is taken to give the encrypted message.
            //Decryption is much the same except with the secret d value (your private key) and n, and you then have to split the string every 2 characters and convert it back to a ASCII readable format. 
            encodedMessage = BigInteger.Pow(encodedMessage, (int)secureKeys[0])%secureKeys[1];
            return encodedMessage;
        }
        /*
        static BigInteger RSADecrypt(BigInteger userInput, BigInteger d, BigInteger n){
            BigInteger decryptedMessage = BigInteger.Pow(userInput, (int)d)%n;
        }
        */


    }
}