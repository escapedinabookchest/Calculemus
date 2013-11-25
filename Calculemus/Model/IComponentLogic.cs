namespace Calculemus.Model
{
    /**
     * The interface IComponentLogic is part of a strategy pattern to be 
     * used for attaching logical operators to the class Component.  
     */
    internal interface IComponentLogic
    {
        bool Calculate(bool[] input);
    }

    /**
     * The following interfaces are used to differentiate the number of 
     * propositions of a logical operator.
     */
    internal interface OneInput : IComponentLogic { }
    internal interface TwoInputs : IComponentLogic { }
    internal interface ThreeInputs : IComponentLogic { }
}
