using System;
using System.Collections.Generic;

namespace Application.Exeptions
{
    public abstract class ExceptionMappings
    {
        private readonly Dictionary<Type, (Type type, string code)> _mappings = new();

        public IReadOnlyDictionary<Type, (Type type, string code)> Mappings => _mappings;

        protected void CreateMap<TFrom, TTarget>(string code) where TFrom : Exception where TTarget : Exception
        {
            var fromType = typeof(TFrom);
            var targetType = typeof(TTarget);

            _mappings.Add(fromType, (targetType, code));
        }
    }
}
