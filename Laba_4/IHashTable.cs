using System.Collections.Generic;

namespace Laba_4
{
    public interface IHashTable
    {
        IReadOnlyCollection<KeyValuePair<int, List<Item>>> Items { get; }

        void Delete(string key);
        void Insert(string key, string value);
        string Search(string key);
    }
}