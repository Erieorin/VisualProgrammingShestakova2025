using System;
using Unity.VisualScripting.Community;
using Unity.VisualScripting;
using Unity.VisualScripting.Community.Utility;


namespace Unity.VisualScripting.Community.Generated
{
    [IncludeInSettings(true)]
    [RenamedFrom(null)]
    public class _Actionint : IAction
    {
        public Action<int> callback;
        public Action<int> instance;
        private bool _initialized;

        public TypeParam[] parameters         { get => new TypeParam[] {  new TypeParam() { name = "obj", type = typeof(int) } }; }

        public string DisplayName         { get => "Action (int)"; }

        public bool initialized         { get => _initialized; set => _initialized = value; }

        public Type GetDelegateType()
        {
            return typeof(Action<int>);
        }

        public object GetDelegate()
        {
            return callback;
        }

        public void Invoke(params object[] parameters)
        {
             callback((int)parameters[0]);
        }

        public void Initialize(Flow flow, ActionNode unit, Action flowAction)
        {
            SetInstance(flow, unit, flowAction); 
            callback = new Action<int>((obj) => { instance(obj); });
            initialized = true;
        }

        public void SetInstance(Flow flow, ActionNode unit, Action flowAction)
        {
            instance = new Action<int>((obj) => { unit.AssignParameters(flow, obj); flowAction(); });
        }

        public void Bind(IDelegate other)
        {
            callback += (Action<int>)other.GetDelegate();
        }

        public void Unbind(IDelegate other)
        {
            callback -= (Action<int>)other.GetDelegate();
        }
    }
}