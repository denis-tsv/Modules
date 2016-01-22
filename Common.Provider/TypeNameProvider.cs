namespace Common.Provider
{
    class TypeNameProvider : ITypeNameProvider
    {
        public string GetTypeName(object obj)
        {
            return obj.GetType().Name;
        }
    }
}
