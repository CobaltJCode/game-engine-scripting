using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{
    
    public TextMeshProUGUI label;
    

    public float prevInput;

    
    public bool clearPrevInput;

    //TODO: Leave this alone
    private EquationType equationType;

    private void Start()
    {
        Clear();
    }

    public void AddInput(string input)
    {
        

        if (clearPrevInput == true) //This should clear the current string
        {
            label.text = string.Empty;
            clearPrevInput = false;
        }

        //TODO: Add the input passed into the AddInput function to the current value of the label
        //      Hint. You can perform the + operations on string data to combine them
        label.text =+ input;

    }

    public void SetEquationAsAdd()
    {
        //TODO: Store the current input value on the text label into the float variable you created.
        //      Hint. You will need to google float.Parse() and pass in the string value of the label.
        
        //TODO: Set the bool you made to true so that the next number that gets typed in clears the calculator display.
        
        prevInput = float.Parse(text.text);
        clearPrevInput = true;
        equationType = EquationType.ADD;
    }

    //TODO: Create a SetEquationAsSubtract function similar to SetEquationAsAdd.
    //      Make sure you set equationType to EquationType.SUBTRACT
    public void SetEquationAsSubtract()
    {
        
        prevInput = float.Parse(text.text);
        clearPrevInput = true;
        equationType = EquationType.SUBTRACT;
    }

    //TODO: Create a SetEquationAsMultiply function similar to SetEquationAsAdd.
    //      Make sure you set equationType to EquationType.Multiply
    public void SetEquationAsMultiply()
    {
        
        prevInput = float.Parse(text.text);
        clearPrevInput = true;
        equationType = EquationType.MULTIPLY;
    }

    //TODO: Create a SetEquationAsDivide function similar to SetEquationAsAdd.
    //      Make sure you set equationType to EquationType.DIVIDE
    public void SetEquationAsDivide()
    {
        
        prevInput = float.Parse(text.text);
        clearPrevInput = true;
        equationType = EquationType.DIVIDE;
    }

    public void Add()
    {
        //TODO: Calculate the sum of the float variable that stores the previous input value and the current input value
        //      Set the text label to display that sum
        label.text = prevInput + label.text;

    }

    //TODO: Implement Subtract function

    public void Subtract()
    {
         

        label.text = prevInput - label.text;

    }

    //TODO: Implement Multiply function

    public void Multiply()
    {

        label.text = prevInput * label.text;

    }

    //TODO: Implement Divide function

    public void Divide()
    {

        label.text = prevInput / label.text;

    }

    public void Clear()
    {
        //TODO: Reset the state of your calculator... reset the display value to a 0, reset the bool variable
        //      that represents if the display should be cleared to true, reset the temporary float variable as well to 0

        
        prevInput = 0;

       
        label.text = 0;

        
        clearPrevInput = true;


        //TODO: Leave this alone
        equationType = EquationType.None;        
    }

    public void Calculate()
    {
        //TODO: Check if equationTypep is Add/Subtract/Multiply/Divide and call the correct function
        if (equationType == EquationType.ADD) Add();
        else if (equationType == EquationType.SUBTRACT) Subtract();
        else if (equationType == EquationType.MULTIPLY) Multiply();
        else if (equationType == EquationType.DIVIDE) Divide();
    }

    //TODO: Leave this alone
    public enum EquationType
    {
        None = 0,
        ADD = 1,
        SUBTRACT = 2,
        MULTIPLY = 3,
        DIVIDE = 4
    }
}
