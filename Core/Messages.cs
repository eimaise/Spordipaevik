using System;
using CSharpFunctionalExtensions;

namespace Core
{
//    public interface IMessages
//    {
//        T Dispatch<T>(IQuery<T> query);
//        Result Dispatch(ICommand command);
//    }
// 
    public class Messages 
    {
        private readonly IServiceProvider _provider;

        protected Messages()
        {
            
        }
        public Messages(IServiceProvider provider)
        {
            _provider = provider;
        }

        public virtual Result Dispatch(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            Result result = handler.Handle((dynamic)command);

            return result;
        }

        public virtual T Dispatch<T>(IQuery<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            T result = handler.Handle((dynamic)query);

            return result;
        }
    }
}
