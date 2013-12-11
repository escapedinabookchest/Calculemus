namespace Calculemus.Model
{
    internal interface IComponentLogic
    {
        bool Calculate();
    }

    /**
     * The following interfaces are used to differentiate the number of 
     * propositions of a logical operator.
     */
    internal interface OneInput : IComponentLogic { }
    internal interface TwoInputs : IComponentLogic { }
    internal interface ThreeInputs : IComponentLogic { }
}
