using System;
using System.Collections.Generic;

namespace EnerBank.Model.Services {
        
    public class ModelFactory 
    // : IModelFactory
    {
        Dictionary<string, Type> _Map = new Dictionary<string, Type>();

        static ModelFactory _Instance = new ModelFactory(); 
        
        public static ModelFactory Instance {
            get {
                return _Instance;
            }
        }

        public ModelFactory Init(){
            _Map.Clear();
            return this;
        }

        public ModelFactory Map<T, W>() 
            where W:T {
            string genericType = typeof(T).Name;
            Type concreteType = typeof(W);
            if(!_Map.ContainsKey(genericType))
                _Map.Add(genericType, concreteType);
            else
                _Map[genericType] = concreteType;

            return this;
        } 

        public T GetNew<T>(params object[] args) {
            string genericType = typeof(T).Name;
            if(!_Map.ContainsKey(genericType))
                throw new NotSupportedException();
            
            if(args.Length>0)
                return (T)Activator.CreateInstance(_Map[genericType], args);
            else
                return (T)Activator.CreateInstance(_Map[genericType]);

        }

    }
}
