using System;

namespace Laba_14
{
	public static class Utils
	{
        public static string ConvertBytesToString(this byte[] hash)
		{
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
        }
	}
}
