namespace Problem010
{
    class PrimeSieve
    {
        private readonly byte[] m_Data;

        public PrimeSieve(int maxSize)
        {
            m_Data = new byte[maxSize/8 + 1];

            for (var i = 0; i < m_Data.Length; i++)
                m_Data[i] = 0xFF;

            ClearPrime(0);
            ClearPrime(1);

            for (var i = 2; i < maxSize; i++)
            {
                if(!IsPrime(i))
                    continue;
                for(var j = i+i; j < maxSize; j += i)
                    ClearPrime(j);
            }
        }

        public bool IsPrime(int num)
        {
            return ((m_Data[num/8]>>(num%8)) & 0x01) == 1;
        }

        public void ClearPrime(int num)
        {
            var index = num/8;
            byte value = m_Data[index];
            var bit = (byte)(0x01 << (num%8));
            value &= (byte)~bit;
            m_Data[index] = value;
        }
    }
}