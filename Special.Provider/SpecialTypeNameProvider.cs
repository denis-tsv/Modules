using Common.Provider;

namespace Special.Provider
{
    class SpecialTypeNameProvider : ITypeNameProvider
    {
        public string GetTypeName(object obj)
        {
            return obj.GetType().FullName;
        }
    }
}
